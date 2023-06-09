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
        Amenazas = new List<Amenaza>();
    }
}
