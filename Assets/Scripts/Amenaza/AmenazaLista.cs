using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "Amenazas")]
public class AmenazaLista : ScriptableObject
{
    public List<Amenaza> Amenazas;

    public void AñadirAmenaza(Amenaza amenaza) 
    {
        Amenazas.Add(amenaza);
    }

    public void ResetearValores() 
    {
        /*
        if (Amenazas != null) 
        {

            Amenazas = new List<Amenaza>();
        }*/
        for (int i = 0; i < Amenazas.Count; i++) 
        {
            Amenazas[i].Estado = Estado.Activa;
        }
    }
}
