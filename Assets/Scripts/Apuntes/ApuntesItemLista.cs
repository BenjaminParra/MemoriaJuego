using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ApuntesItem")]
public class ApuntesItemLista : ScriptableObject
{
    public List<ApunteItem> Apuntes;

     public void ResetearValores()
    {
        for (int i = 0; i < Apuntes.Count; i++)
        {
            Apuntes[i].pistaObtenidaString = "Debería conversar con esta persona";
            Apuntes[i].conversadoBool = false;
            Apuntes[i].pistaObtenidaBool = false;
            Apuntes[i].numeroDireccion = 0;
        }
    }
    
}
