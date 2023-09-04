using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivoManager : Singleton<ActivoManager>
{
    [Header("Config")]
    [SerializeField] private ActivoTarjeta activoTarjetaPrefab;
    [SerializeField] private Transform activoContenedor;


    [Header("nombreActivo")]
    [SerializeField] private TextMeshProUGUI nombreTMP;

    [Header("Datos basicos Activos")]
    [SerializeField] private Image iconoActivo;
    [SerializeField] private TextMeshProUGUI nombreActivo;
    [SerializeField] private TextMeshProUGUI ubicacionActivo;
    [SerializeField] private TextMeshProUGUI descripcionActivo;
    [SerializeField] private TextMeshProUGUI seguridadActivo;
    [SerializeField] private TextMeshProUGUI accesoActivo;

    [Header("Panel Pistas 1")]
    //[SerializeField] private TextMeshProUGUI identificadorPista1;
    [SerializeField] private TextMeshProUGUI cuerpoPista1;

    [Header("Panel Pistas 2")]
    //[SerializeField] private TextMeshProUGUI identificadorPista2;
    [SerializeField] private TextMeshProUGUI cuerpoPista2;

    [Header("Panel Pistas 3")]
    //[SerializeField] private TextMeshProUGUI identificadorPista3;
    [SerializeField] private TextMeshProUGUI cuerpoPista3;


    [Header("Activos")]
    [SerializeField] private ActivosLista activos;

    public ActivoBase ActivadoSeleccionado { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //CargarActivos();
    }

    public void CargarActivos()
    {
        for (int i = 0; i < activos.Activos.Length; i++)
        {
            if (activos.Activos[i] != null)
            {
                ActivoTarjeta activo = Instantiate(activoTarjetaPrefab, activoContenedor);
                activo.ConfigurarActivoTarjeta(activos.Activos[i]);
                activos.Activos[i].id = i;
            }
        }
    }

    public void MostrarActivo(ActivoBase activo)
    {
        ActivadoSeleccionado = activo;
        nombreTMP.text = activo.nombre;
        iconoActivo.sprite = activo.iconoActivo;
        ubicacionActivo.text = $"Ubicacion: {activo.ubicacion}";
        descripcionActivo.text = activo.descripcion;

        seguridadActivo.text = $"Nivel de Seguridad: {activo.nivelSeguridad.ToString()}";
        accesoActivo.text = $"Acceso: {activo.acceso.ToString()}";

        cuerpoPista1.text = activo.pistas[0];
        cuerpoPista2.text = activo.pistas[1];
        cuerpoPista3.text = activo.pistas[2];

    }
}

