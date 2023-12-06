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
    public bool Visible;
    public bool Publicado;
    public bool EsTecnologia;

    [Header("Informacion")]
    public bool EsInteractuable;

    public ComputadorItem CopiarItem() 
    {
        ComputadorItem nuevaInstancia = Instantiate(this);
        return nuevaInstancia;
    }
    public virtual bool AbrirItem() 
    { 
        return true;
    }

    public void ResetearValores() 
    {
        if (EsTecnologia) 
        {
            Visible = false;
        }
        Publicado = false;
    }

    
}
