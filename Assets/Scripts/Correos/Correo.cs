using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum TipoCorreo
{
    Limpio,
    Malicioso
}
[Serializable]

public class Correo
{
    public string Nombre;
    public TipoCorreo TipoCorreo;

    [Header("Remitente - Asunto")]

    public string NombreRemitente;
    public string CorreoRemitente;
    public Sprite IconoRemitente;

    public string AsuntoCorreo;

    [Header("Cuerpo Correo")]
    [TextArea] public string CuerpoCorreo;

    [HideInInspector] public int identificador;


}
