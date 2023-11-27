using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CorreoManager : Singleton<CorreoManager>
{
    [Header("Config")]
    [SerializeField] private CorreoTarjeta correoTarjetaPrefab;
    [SerializeField] private Transform correoContenedor;

    [Header("Correo Info")]
    [SerializeField] private TextMeshProUGUI asuntoTMP;
    [SerializeField] private TextMeshProUGUI estadoCorreo;

    [Header("Remitente Info")]
    [SerializeField] private Image iconoRemitente;
    [SerializeField] private TextMeshProUGUI nombreRemitente;
    [SerializeField] private TextMeshProUGUI correoRemitente;

    [Header("Cuerpo Correo")]
    [SerializeField] private TextMeshProUGUI cuerpoCorreo;

    [Header("Botones")]
    [SerializeField] private Button buttonReport;
    [SerializeField] private Button buttonAprobar;

    [Header("Correos")]
    [SerializeField] private CorreoLista correos;

    [Header("Enemigos")]
    [SerializeField] private GameObject[] enemigos;

    [Header("Panel Botones")]
    [SerializeField] private GameObject panelBotonesReport;


    [Header("Botones Bandejas")]
    [SerializeField] private GameObject botonBandejaSalida;
    [SerializeField] private GameObject botonBandejaEntrada;
    [SerializeField] private AmenazaLista amenazaLista;



    [SerializeField] private GameObject amenazaPishing;

    public Correo CorreoSeleccionado { get; set; }
    private void Start()
    {
        CargarCorreos();
    }

    private void Update()
    {
        //CargarCorreos();
    }
    private void CargarCorreos() 
    {
        for (int i = 0;i < correos.Correos.Length;i++) 
        {
            if (correos.Correos[i] != null && correos.Correos[i].Visibilidad && correos.Correos[i].Publicado == false)
            {
                CorreoTarjeta correo = Instantiate(correoTarjetaPrefab, correoContenedor);
                correo.ConfigurarCorreoTarjeta(correos.Correos[i]);
                correos.Correos[i].identificador = i;
                correos.Correos[i].Publicado = true;
            }
            
        }
    }


    public void MostrarCorreo(Correo correo) 
    {
        CorreoSeleccionado = correo;
        asuntoTMP.text = correo.AsuntoCorreo;
        estadoCorreo.text = correo.EstadoCorreo.ToString();
        iconoRemitente.sprite = correo.IconoRemitente;
        nombreRemitente.text = correo.NombreRemitente;
        correoRemitente.text = correo.CorreoRemitente;

        if (correo.EstadoCorreo == EstadoCorreo.PorEnviar)
        {
            if (!panelBotonesReport.activeSelf)
            {
                panelBotonesReport.SetActive(true);
            }
        }
        else
        {
            panelBotonesReport.SetActive(false);
        }

        //Verifico si el enemigo asociado a dicha amenaza esta activo
        /*
        if (enemigos[CorreoSeleccionado.identificador].activeSelf)
        {
            panelBotonesReport.SetActive(false);
        }
        else
        {

            panelBotonesReport.SetActive(true);
        }*/
        cuerpoCorreo.text = correo.CuerpoCorreo;

        

    }

    public void ActivarEnemigo() 
    {
        if (CorreoSeleccionado.TipoCorreo == TipoCorreo.Malicioso)
        {
            enemigos[CorreoSeleccionado.identificador].SetActive(true);
            Amenaza amenaza = new Amenaza();
            amenaza.CrearAmenaza(amenazaPishing.GetComponent<AmenazaMadre>());
            amenazaLista.AñadirAmenaza(amenaza);
            amenaza.ModificarCantidad(-Math.Abs(1));
            panelBotonesReport.SetActive(false);
        }
        else 
        {
            panelBotonesReport.SetActive(false);
            return;
        }
        
    }

    public void ReportarEnemigo()
    {
        if (CorreoSeleccionado.TipoCorreo == TipoCorreo.Malicioso)
        {

           
            Amenaza amenaza = new Amenaza();
            amenaza.CrearAmenaza(amenazaPishing.GetComponent<AmenazaPhising>());
            amenazaLista.AñadirAmenaza(amenaza);
            amenaza.ModificarCantidad(2);
            panelBotonesReport.SetActive(false);
        }
        else 
        {
            panelBotonesReport.SetActive(false);
            return;
        }
    }

    
}
