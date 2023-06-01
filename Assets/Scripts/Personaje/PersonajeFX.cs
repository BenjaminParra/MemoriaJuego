using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoPersonaje
{
    Player,
    IA
}
public class PersonajeFX : MonoBehaviour
{

    [Header("Pooler")]
    [SerializeField] private ObjectPooler pooler;

    [Header("Config")]
    [SerializeField] private GameObject canvasTextoAnimacionPrefab;
    [SerializeField] private Transform canvasTextoPosicion;

    [Header("Tipo Personaje")]
    [SerializeField] private TipoPersonaje tipoPersonaje;


    private EnemigoVida _enemigoVida;

    private void Awake()
    {
        _enemigoVida = GetComponent<EnemigoVida>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pooler.CrearPooler(canvasTextoAnimacionPrefab);
    }

    private IEnumerator IEMostrarTexto(float cantidad, Color color) 
    {
        GameObject nuevoTextoGO = pooler.ObtenerInstancia();
        TextoAnimacion texto = nuevoTextoGO.GetComponent<TextoAnimacion>();
        texto.EstablecerTexto(cantidad, color);
        nuevoTextoGO.transform.SetParent(canvasTextoPosicion);
        nuevoTextoGO.transform.position = canvasTextoPosicion.position;
        nuevoTextoGO.SetActive(true);

        yield return new WaitForSeconds(1f);
        nuevoTextoGO.SetActive(false);

        nuevoTextoGO.transform.SetParent(pooler.ListaContenedor.transform);
    }


    private void RespuestaDa�oRecibidoHaciaPlayer(float da�o)
    {
        if (tipoPersonaje == TipoPersonaje.Player)
        {
            StartCoroutine(IEMostrarTexto(da�o, Color.black));
        }
        
    }


    private void RespuestaDa�oHaciaEnemigo(float da�o, EnemigoVida enemigoVida)
    {
        if (tipoPersonaje == TipoPersonaje.IA && _enemigoVida == enemigoVida && _enemigoVida.GetComponent<VidaBase>().Salud > 0f) 
        {
            StartCoroutine(IEMostrarTexto(da�o, Color.magenta));
        }
    }

    private void OnEnable()
    {
        IAController.EventoDa�oRealizado += RespuestaDa�oRecibidoHaciaPlayer;
        PersonajeAtaque.EventoEnemigoDa�ado += RespuestaDa�oHaciaEnemigo;
    }

    private void OnDisable()
    {
        IAController.EventoDa�oRealizado -= RespuestaDa�oRecibidoHaciaPlayer;
        PersonajeAtaque.EventoEnemigoDa�ado -= RespuestaDa�oHaciaEnemigo;
    }
}
