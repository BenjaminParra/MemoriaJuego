using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TiendaControlManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ControlTienda controlTiendaPrefab;
    [SerializeField] private Transform panelContenedor;


    [Header("Controles")]
    [SerializeField] private ControlVenta[] controlesDisponibles;


    // Start is called before the first frame update
    void Start()
    {
        CargarControlesEnVenta(); 
    }

    private void CargarControlesEnVenta() 
    {
        for (int i = 0; i< controlesDisponibles.Length; i++) 
        {
            ControlTienda controlTienda = Instantiate(controlTiendaPrefab, panelContenedor);
            controlTienda.ConfigurarControlEnVenta(controlesDisponibles[i]);
        }
    }

    
}
