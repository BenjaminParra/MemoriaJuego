using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;

    //Propiedad que solo se modifica en esta clase, pero que se obtiene de cualquier otra
    public bool Derrotado { get;private set; }
    public bool PuedeSerCurado => Salud < saludMaxima;

    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D= GetComponent<BoxCollider2D>();
    }
    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud,saludMaxima);
    }
    private void Update()
    {   
        //asi verificamos si fue presionada una tecla
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            RecibirDaño(10);
        }
        //if (Derrotado != true)
        //{
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RestaurarSalud(10);
        }
        //}
        
    }
    public void RestaurarSalud(float cantidad) 
    {
        if (Derrotado)
        {
            return;
        }
        if (PuedeSerCurado) 
        { 
            Salud += cantidad;
            if (Salud > saludMaxima) 
            { 
                Salud = saludMaxima;
            }
            ActualizarBarraVida(Salud, saludMaxima);
        }
    }
    protected override void ActualizarBarraVida(float vidaActual, float vidaMaxima)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMaxima);
    }
    public void RestaurarPersonaje()
    {
        boxCollider2D.enabled = true;
        Derrotado = false;
        Salud = saludInicial;
        ActualizarBarraVida(Salud, saludInicial);
    }

    protected override void PersonajeDerrotado()
    {
        boxCollider2D.enabled = false;
        Derrotado = true;
        //Si el evento no es nulo, se invoca el evento
        EventoPersonajeDerrotado?.Invoke();
    }
}
