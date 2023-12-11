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
            
            Correos[i].Publicado = false;
            if (Correos[i].EstadoCorreo == EstadoCorreo.Enviado)
            {
                Correos[i].EstadoCorreo = EstadoCorreo.PorEnviar;
            }
            if (Correos[i].EstadoCorreo == EstadoCorreo.Respuesta)
            {
                Correos[i].Visibilidad = false;
            }
            if (Correos[i].EstadoCorreo == EstadoCorreo.PorEnviar)
            {
                Correos[i].Visibilidad = false;
            }
            else 
            {
                Correos[i].Visibilidad = true;
            }
            
        }
    }
}
