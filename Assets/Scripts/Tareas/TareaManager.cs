using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TareaManager : Singleton<TareaManager>
{
    [Header("Config")]
    [SerializeField] private TareaTarjeta tareaTarjetaPrefab;
    [SerializeField] private Transform panelContenedor;

    [Header("Tareas")]
    [SerializeField] private TareaLista tareasDisponibles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarTareaConID(int id) 
    {
        TareaTarjeta tareaTarjeta = Instantiate(tareaTarjetaPrefab, panelContenedor);
        tareaTarjeta.ConfigurarTarea(tareasDisponibles.Tareas[id]);
    }


}
