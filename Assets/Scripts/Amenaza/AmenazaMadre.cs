using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmenazaMadre : MonoBehaviour
{
    public string nombreOriginal;
    public Estado estadoOriginal;
    public string tipoOriginal;
    public string consejosOriginal;
    public string controlesRecomendadosOriginal;
    public int cantidadDeAmenazas;
    public string controlParaSerMitigado;  //esto puede ser un enum (debilidad)




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
    }

}
