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

public enum EstadoCorreo
{
    Enviado,
    PorEnviar,
    Respuesta,
    Recibido
}
[Serializable]

public class Correo
{
    public string Nombre;
    public TipoCorreo TipoCorreo;
    public EstadoCorreo EstadoCorreo;
    public bool Visibilidad;
    //con esta variable controlamos que solo se suba una vez
    public bool Publicado;

    public int IdTarea;
    public int IDCorreoRespuesta;

    [Header("Variables ink para el remitente")]
    public string NombreVariableInkRemitente;
    public bool VariableCambiada;

    [Header("Remitente - Asunto")]

    public string NombreRemitente;
    public string CorreoRemitente;
    public Sprite IconoRemitente;

    public string AsuntoCorreo;

    [Header("Cuerpo Correo")]
    [TextArea] public string CuerpoCorreo;

    [HideInInspector] public int identificador;

    

}
