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

    [Header("Variables archivo ink")]
    [SerializeField] public string nombreVariableInicioControl;
    //permite reconocer si el control se ha iniciado o no
    public bool inicioControl;
    public bool finControl;

    [Header("Descripcion Proceso")]
    [TextArea] public string DescripcionProceso;
    //aqui pueden ir variables relacionadas con el archivo ink
    public string NombreVariableInkProceso;
    public bool ValorVariableInkProceso;

    [Header("Descripcion Persona")]
    [TextArea] public string DescripcionPersona;
    public string NombreVariableInkPersona;
    public bool ValorVariableInkPersona;
    public int IdCorreo;

    [Header("Descripcion Tecnologia")]
    [TextArea] public string DescripcionTecnologia;
    public string NombreVariableInkTecnologia;
    public bool ValorVariableInkTecnologia;
}
