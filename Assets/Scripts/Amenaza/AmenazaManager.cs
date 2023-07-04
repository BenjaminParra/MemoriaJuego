using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//asi la llamamos con instance en otras clases
public class AmenazaManager : Singleton<AmenazaManager>
{
    //agregar a la amenaza madre una cantidad y solo cuando esa cantidad llegue a cero cambiar estado a mitigado
    public bool ExisteAmenazaTipo(AmenazaLista amenazaLista, string tipo)
    {
        for (int i = 0; i < amenazaLista.Amenazas.Count; i++)
        {
            if (amenazaLista.Amenazas[i].Nombre == tipo && amenazaLista.Amenazas[i].Estado == Estado.Activa)
            {
                return true;
            }
        }
        return false;
    }
    /*
    public Amenaza CrearAmenaza(AmenazaMadre amenazaPrefab) 
    {
        Amenaza amenazaNueva = new Amenaza();
        amenazaNueva.CrearAmenaza(amenazaPrefab.nombreOriginal,
                amenazaPrefab.estadoOriginal,
                amenazaPrefab.tipoOriginal,
                amenazaPrefab.consejosOriginal,
                amenazaPrefab.controlesRecomendadosOriginal);
        return amenazaNueva;
    }*/
}
