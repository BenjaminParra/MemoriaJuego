using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TecnologiaManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private TecnologiaTienda tecnologiaTiendaPrefab;
    [SerializeField] private Transform panelContenedor;


    [Header("Tecnologias")]
    [SerializeField] private TecnologiaVenta[] tecnologiasDisponibles;

    private void Start()
    {
        CargarTecnologiasEnVenta();
    }
    private void CargarTecnologiasEnVenta() 
    {
        for (int i = 0; i < tecnologiasDisponibles.Length; i++) 
        {
            TecnologiaTienda tecnologiaTienda = Instantiate(tecnologiaTiendaPrefab, panelContenedor);
            tecnologiaTienda.ConfigurarTecnologiaEnVenta(tecnologiasDisponibles[i]);
        }
    }
}
