using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;
    [SerializeField] private string layerAtacar;
    private readonly int direccionX = Animator.StringToHash("X");
    private readonly int direccionY = Animator.StringToHash("Y");
    private readonly int derrotado = Animator.StringToHash("Derrotado");
    private Animator animator;
    private PersonajeMovimiento personajeMovimiento;
    private PersonajeAtaque personajeAtaque;

    [SerializeField] private GameObject mensaje;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        personajeMovimiento = GetComponent<PersonajeMovimiento>();
        personajeAtaque = GetComponent<PersonajeAtaque>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        ActualizarLayers(); 
        //se verifica que este en movimiento
        if (personajeMovimiento.EnMovimiento)
        {
            animator.SetFloat(direccionX, personajeMovimiento.DireccionMovimiento.x);
            animator.SetFloat(direccionY, personajeMovimiento.DireccionMovimiento.y);
        }
        else
        {
            return;
        }
        
    }
    private void ActivarLayer(string layer) 
    {
        //Se desactivan todos los layer
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        //Se activa el layer a traves del index
        animator.SetLayerWeight(animator.GetLayerIndex(layer), 1);
    }

    private void ActualizarLayers() 
    {
        if (personajeAtaque.Atacando)
        {
            ActivarLayer(layerAtacar);
        }
        else if (personajeMovimiento.EnMovimiento)
        {
            ActivarLayer(layerCaminar);
            mensaje.SetActive(false);
        }
        else
        {
            ActivarLayer(layerIdle);
            mensaje.SetActive(true);

        }
    }

    public void RevivirPersonaje()
    {
        ActivarLayer(layerIdle);
        animator.SetBool(derrotado, false);
    }
    private void PersonajeDerrotadoRespuesta() 
    {
        //Verificamos si nos encontramos en el layerIdle del componente animator
        if (animator.GetLayerWeight(animator.GetLayerIndex(layerIdle))==1)
        {
            animator.SetBool(derrotado, true);
        }
        else
        {
            ActivarLayer(layerIdle);
            animator.SetBool(derrotado, true);
        }
    }

    private void OnEnable()
    {
        PersonajeVida.EventoPersonajeDerrotado += PersonajeDerrotadoRespuesta;
    }
    private void OnDisable()
    {
        PersonajeVida.EventoPersonajeDerrotado -= PersonajeDerrotadoRespuesta;
    }

}
