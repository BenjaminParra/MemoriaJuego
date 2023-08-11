using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[Serializable]
public class ApunteItem 
{
    public string nombreNPC;
    public string pistaObtenida;
    public string conversado;
    public string pista;
    public string direccion;
    public int id;

    public bool pistaObtenidaBool;
    public bool conversadoBool;
    public string pistaObtenidaString;
    public int numeroDireccion;


    [Header("Icono")]
    public Sprite iconoNPC;
}
