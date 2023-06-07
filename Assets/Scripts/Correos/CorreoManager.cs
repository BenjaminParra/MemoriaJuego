using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorreoManager : Singleton<CorreoManager>
{
    [Header("Config")]
    [SerializeField] private CorreoTarjeta correoTarjetaPrefab;
    [SerializeField] private Transform correoContenedor;

    [Header("Correos")]
    [SerializeField] private CorreoLista correos;

    private void Start()
    {
        CargarCorreos();
    }
    private void CargarCorreos() 
    {
        for (int i = 0;i < correos.Correos.Length;i++) 
        {
            CorreoTarjeta correo = Instantiate(correoTarjetaPrefab, correoContenedor);
            correo.ConfigurarCorreoTarjeta(correos.Correos[i]); 
        }
    }
}
