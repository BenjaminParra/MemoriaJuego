using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoActivo 
{
    Datos,
    Aplicaciones,
    Dispositivos,
    Red,
    Usuarios,
    NA
}

public enum FuncionSeguridad 
{
    Proteger,
    Identificar,
    Detectar,
    Responder,
    Recuperar
}

public class InventarioControl : ScriptableObject
{
    [Header("Atributos")]
    public string IdControl;
    public string NombreControl;
    public string IdSalvaguardas;
    public string NombreSalvaguardas;
    public TipoActivo TipoActivo;
    public FuncionSeguridad FuncionSeguridad;
    [TextArea] public string Descripcion;

    [Header("Descripcion Proceso")]
    [TextArea] public string DescripcionProceso;
    //aqui pueden ir variables relacionadas con el archivo ink

    [Header("Descripcion Persona")]
    [TextArea] public string DescripcionPersona;

    [Header("Descripcion Tecnologia")]
    [TextArea] public string DescripcionTecnologia;
}
