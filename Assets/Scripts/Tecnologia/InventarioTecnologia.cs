using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Soporte 
{
    Nulo,
    Instalacion,
    Personalizado
}

public enum Actualizaciones
{
    Desactualizado,
    Periodicamente, 
    Desconocido
}
public class InventarioTecnologia : ScriptableObject
{
    [Header("Atributos")]
    public string Nombre;
    public Sprite Icono;
    public string SalvaguardasAsociado;
    public int TiempoNecesarioEstudio;
    public Soporte Soporte;
    public Actualizaciones Actualizaciones;
    public int IdTecnologiaComputador;

    public ComputadorItem ComputadorItem;

    [Header("Descripcion Tecnologia")]
    [TextArea] public string DescripcionTecnologia;
    public string NombreVariableInkTecnologia;
    public bool ValorVariableInkTecnologia;
}
