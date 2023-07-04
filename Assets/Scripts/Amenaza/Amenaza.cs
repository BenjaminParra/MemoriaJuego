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
    public int CantidadDeAmenazas;



    public void CrearAmenaza(AmenazaMadre amenazaPrefab)
    {
        Nombre = amenazaPrefab.nombreOriginal;
        Estado = amenazaPrefab.estadoOriginal;
        Tipo = amenazaPrefab.tipoOriginal;
        Consejos = amenazaPrefab.consejosOriginal;
        ControlesRecomendados = amenazaPrefab.controlesRecomendadosOriginal;
        CantidadDeAmenazas = 1;

       
    }

    public void ModificarCantidad(int numero) 
    {
        if (numero < 0)
        {
            if (CantidadDeAmenazas == 1)
            {
                CantidadDeAmenazas = 0;
                Estado = Estado.Mitigado;
            }
        }
        else 
        {
            CantidadDeAmenazas = 2;
        }
    }

    /*
    public bool ExisteEstaAmenaza()
    {
        if (cantidadDeAmenazas != 0)
        {
            return true;
        }
        return false;
    }
    public void AumentaCandidadAmenazas()
    {
        if (ExisteEstaAmenaza())
        {
            cantidadDeAmenazas += 1;
        }
        else
        {
            cantidadDeAmenazas = 1;
        }
    }*/

}
