using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum TiposDeAtaque
{
    Melee,
    Embestida
}
public class IAController : MonoBehaviour
{
    public static Action<float> EventoDañoRealizado;

    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Personaje")]
    [SerializeField] private Personaje personaje;
    //cerebro enemigo
    [Header("Estados")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;


    [Header("Config")]
    [SerializeField] private float rangoDeteccion;
    [SerializeField] private float rangoDeataque;
    [SerializeField] private float rangoDeEmbestida;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadDeEmbestida;
    [SerializeField] private LayerMask personajeLayerMask;

    [Header("Ataque")]
    [SerializeField] private float daño;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] TiposDeAtaque tipoAtaque;

    [Header("Debug")]
    [SerializeField] private bool mostrarDeteccion;
    [SerializeField] private bool mostrarRangoAtaque;
    [SerializeField] private bool mostrarRangoEmbestida;


    private float tiempoParaSiguienteAtaque;
    public float RangoDeteccion => rangoDeteccion;
    public TiposDeAtaque TipoAtaque => tipoAtaque;
    public float VelocidadMovimiento => velocidadMovimiento;
    public float Daño => daño;
    public float RangoDeAtaqueDeterminado => tipoAtaque == TiposDeAtaque.Embestida ? rangoDeEmbestida : rangoDeataque;


    private BoxCollider2D boxCollider2D;
    public LayerMask PersonajeLayerMask => personajeLayerMask;
    public EnemigoMovimiento EnemigoMovimiento { get; set; }
    public Personaje Personaje => personaje;
    public Transform PersonajeReferencia { get; set; }
    public IAEstado EstadoActual { get;  set; }

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        EstadoActual = estadoInicial;
        EnemigoMovimiento = GetComponent<EnemigoMovimiento>();
    }

    private void Update()
    {
        EstadoActual.EjecutarEstado(this);
    }

    public void CambiarEstado(IAEstado nuevoEstado) 
    {
        if (estadoDefault != nuevoEstado) 
        {
            EstadoActual = nuevoEstado; 
        }
    }

    public void AtaqueMelee(float cantidad) 
    {
        if (PersonajeReferencia != null) 
        {
            AplicarDañoAlPersonaje(cantidad);
        }
    }
    public void AtaqueEmbestida(float cantidad) 
    {
        StartCoroutine(IEEmbestida(cantidad));
    }
    private IEnumerator IEEmbestida(float cantidad) 
    {
        Vector3 personajePosicion = PersonajeReferencia.position;
        Vector3 posicionInicial = transform.position;
        Vector3 direccionHaciaPersonaje = (personajePosicion - posicionInicial).normalized;
        Vector3 posicionDeAtaque = personajePosicion - direccionHaciaPersonaje * 0.5f;

        boxCollider2D.enabled = false;
        float transicionDeAtaque = 0f;
        while (transicionDeAtaque <= 1f) 
        {
            transicionDeAtaque += Time.deltaTime * velocidadMovimiento;
            float interpolacion = (-Mathf.Pow(transicionDeAtaque, 2) + transicionDeAtaque) * 4f;
            transform.position = Vector3.Lerp(posicionInicial, posicionDeAtaque, interpolacion);
            yield return null;
        }
        if (PersonajeReferencia != null)
        {
            AplicarDañoAlPersonaje(cantidad);
        }
        boxCollider2D.enabled = true;

    }

    public void AplicarDañoAlPersonaje(float cantidad) 
    {
        float dañoPorRealizar = 0;
        if (Random.value < stats.PorcentajeBloqueo / 100) 
        {
            return;
        }

        //asi el daño minimamente es 1
        dañoPorRealizar = Mathf.Max(cantidad - stats.Defensa,1f);
        PersonajeReferencia.GetComponent<PersonajeVida>().RecibirDaño(dañoPorRealizar);
        EventoDañoRealizado?.Invoke(dañoPorRealizar);
    }

    public bool PersonajeEnRangoDeAtaque(float rango) 
    {
        float distanciaHaciaPersonaje = (PersonajeReferencia.position - transform.position).sqrMagnitude;
        if (distanciaHaciaPersonaje < Mathf.Pow(rango, 2))
        {
            return true;
        }
        return false;
    }

    public bool EsTiempoDeAtacar() 
    {
        if (Time.time > tiempoParaSiguienteAtaque)
        {
            return true;
        }
        return false;
    }

    public void ActualizarTiempoEntreAtaques() 
    {
        tiempoParaSiguienteAtaque = Time.time + tiempoEntreAtaques;
    }

    private void OnDrawGizmos()
    {
        if (mostrarDeteccion) 
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        }
        if (mostrarRangoAtaque) 
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, rangoDeataque);
        }

        if (mostrarRangoEmbestida)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangoDeEmbestida);
        }
    }
}
