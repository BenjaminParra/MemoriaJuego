using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVida : VidaBase
{
    public static Action<float> EventoEnemigoDerrotado;

    [Header("Vida")]
    [SerializeField] private EnemigoBarraVida barraVidaPrefab;
    [SerializeField] private Transform barraVidaPosicion;

    [Header("Rastros")]
    [SerializeField] private GameObject rastros;




    private EnemigoBarraVida enemigoBarraVidaCreada;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private IAController controller;
    private EnemigoInteraccion enemigoInteraccion;
    private EnemigoMovimiento enemigoMovimiento;
    private EnemigoLoot enemigoLoot;
    private PersonajeAtaque personajeAtaque;

    protected override void Start()
    {
        base.Start();
        CrearBarraVida();
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        controller = GetComponent<IAController>();
        enemigoInteraccion = GetComponent<EnemigoInteraccion>();
        enemigoMovimiento = GetComponent<EnemigoMovimiento>();
        personajeAtaque = GetComponent<PersonajeAtaque>();
        enemigoLoot = GetComponent<EnemigoLoot>();
    }

    private void CrearBarraVida() 
    {
        enemigoBarraVidaCreada = Instantiate(barraVidaPrefab, barraVidaPosicion);
        ActualizarBarraVida(Salud, saludMaxima);
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMaxima)
    {
        enemigoBarraVidaCreada.ModificarSalud(vidaActual, vidaMaxima);
    }

    protected override void PersonajeDerrotado()
    {
        DesactivarEnemigo();
        EventoEnemigoDerrotado(enemigoLoot.ExpGanada);
        QuestManager.Instance.AñadirProgreso("Mata10", 1);
        QuestManager.Instance.AñadirProgreso("Mata25", 1);
        QuestManager.Instance.AñadirProgreso("Mata50", 1);
    } 

    private void DesactivarEnemigo() 
    {
        //se desactivan
        spriteRenderer.enabled = false;
        controller.enabled = false;
        boxCollider2D.isTrigger = true;
        enemigoInteraccion.DesactivarSpritesSeleccion();
        enemigoMovimiento.enabled = false;
        enemigoBarraVidaCreada.gameObject.SetActive(false);
        rastros.SetActive(true);
        
    }

    
}
