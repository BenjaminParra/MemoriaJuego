using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NivelSeguridad
{
    Alto,
    Medio,
    Bajo,
    Nulo
}
public enum Acceso
{
    Restringido,
    Libre
}
[Serializable]
public class ActivoBase
{
    public string nombre;
    public string descripcion;
    public string ubicacion;
    public NivelSeguridad nivelSeguridad;
    public Acceso acceso;
    public int id;
    public string[] pistas;

    [Header("Icono")]
    public Sprite iconoActivo;

    
}
