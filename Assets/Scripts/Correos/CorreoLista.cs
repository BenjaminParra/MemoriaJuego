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
            Correos[i].Visibilidad = true;
            Correos[i].Publicado = false;
            if (Correos[i].EstadoCorreo == EstadoCorreo.Enviado)
            {
                Correos[i].EstadoCorreo = EstadoCorreo.PorEnviar;
            }
            if (Correos[i].EstadoCorreo == EstadoCorreo.Recibido)
            {
                Correos[i].Visibilidad = false;
            }
            
        }
    }
}
