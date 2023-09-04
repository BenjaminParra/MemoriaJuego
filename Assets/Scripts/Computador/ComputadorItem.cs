using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComputadorItem : ScriptableObject
{
    [Header("Parametros")]
    public string ID;
    public string Nombre;
    public Sprite Icono;
    [TextArea]public string Descripcion;

    [Header("Informacion")]
    public bool EsInteractuable;
}
