using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmenazaPhising : AmenazaMadre
{
    private void Start()
    {
        nombreOriginal = "Pishing";
        estadoOriginal = Estado.Activa;
        tipoOriginal = "Robo de informacion";
        consejosOriginal = "Cuidate";
        controlesRecomendadosOriginal = "Mucho te";
        cantidadDeAmenazas = 1;

        //CrearAmenaza();
        //inicializa amenaza AumentaCandidadAmenazas();
    }

}
