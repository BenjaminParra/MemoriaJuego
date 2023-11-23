using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "Correos")]
public class CorreoLista : ScriptableObject
{
    public Correo[] Correos;

    public void ResetearValores()
    {
        for (int i = 0; i < Correos.Length; i++)
        {
            Correos[i].Visibilidad = false;
            Correos[i].Publicado = false;
        }
    }
}
