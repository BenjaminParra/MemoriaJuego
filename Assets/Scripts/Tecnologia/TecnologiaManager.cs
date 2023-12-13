using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TecnologiaManager : Singleton<TecnologiaManager>
{
    [Header("Config")]
    [SerializeField] private TecnologiaTienda tecnologiaTiendaPrefab;
    [SerializeField] private Transform panelContenedor;


    [Header("Tecnologias")]
    [SerializeField] private TecnologiaVenta[] tecnologiasDisponibles;


    public bool tecnologiaControl1Comprada;
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
    public void CambiaEstado(int caso) 
    {
        switch (caso)
        {
            case 0:
                tecnologiaControl1Comprada = true; break;
        }
    }

    


}
