using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Estado 
{
    Activo, 
    Mitigado,
    Inactivo
}

[CreateAssetMenu(menuName = "Amenaza")]
public class AmenazaMadre : ScriptableObject
{
    [Header("Parametros")]
    public string nombre;
    public string descripcion;
    public int idActivoAsociado;
    public Estado estadoAmenaza;
    public InventarioControl controlAsociado;
    

    [Header("Primer ataque")]
    public float porcentajePrimerAtaque;
    public float tiempoPrimerAtaque;
    public bool primerAtaqueRealizado;

    [Header("Segundo ataque")]
    public float porcentajeSegundoAtaque;
    public float tiempoSegundoAtaque;
    public bool segundoAtaqueRealizado;


    [Header("Tercer ataque")]
    public float porcentajeTercerAtaque;
    public float tiempoTercerAtaque;
    public bool tercerAtaqueRealizado;


    //agregar metodo que puedan ser operados por la amenaza
    // ya se modificar variables
}
