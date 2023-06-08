using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Estado
{
    Activa,
    Mitigado
}

[Serializable]
public class Amenaza  
{
    public string Nombre;
    public Estado Estado;
    public string Tipo;
    [TextArea] public string Consejos;
    [TextArea] public string ControlesRecomendados;



    public void CrearAmenaza(string nombre, Estado estado, string tipo, string consejos, string controlesRecomendados)
    {
        Nombre = nombre;
        Estado = estado;
        Tipo = tipo;
        Consejos = consejos;
        ControlesRecomendados = controlesRecomendados;

       
    }

}
