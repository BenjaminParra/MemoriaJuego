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

    [SerializeField] private AmenazaLista amenazaLista;


    [SerializeField] private GameObject amenazaPishing;

    public Correo CorreoSeleccionado { get; set; }
    private void Start()
    {
        CargarCorreos();
    }
    private void CargarCorreos() 
    {
        for (int i = 0;i < correos.Correos.Length;i++) 
        {
            if (correos.Correos[i] != null)
            {
                CorreoTarjeta correo = Instantiate(correoTarjetaPrefab, correoContenedor);
                correo.ConfigurarCorreoTarjeta(correos.Correos[i]);
                correos.Correos[i].identificador = i;
            }
            
        }
    }

    public void MostrarCorreo(Correo correo) 
    {
        CorreoSeleccionado = correo;
        asuntoTMP.text = correo.AsuntoCorreo;

        iconoRemitente.sprite = correo.IconoRemitente;
        nombreRemitente.text = correo.NombreRemitente;
        correoRemitente.text = correo.CorreoRemitente;

        //Verifico si el enemigo asociado a dicha amenaza esta activo
        if (enemigos[CorreoSeleccionado.identificador].activeSelf)
        {
            panelBotonesReport.SetActive(false);
        }
        else
        {

            panelBotonesReport.SetActive(true);
        }
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
