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
    [SerializeField] private Transform correoContenedorSalida;
    [SerializeField] private Transform correoContenedorEntrada;

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

    [Header("Panel BandejaSalida")]

    [SerializeField] private GameObject panelInfo;


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
            if (correos.Correos[i] != null && correos.Correos[i].Visibilidad && correos.Correos[i].Publicado == false && correos.Correos[i].EstadoCorreo == EstadoCorreo.PorEnviar)
            {
                CorreoTarjeta correo = Instantiate(correoTarjetaPrefab, correoContenedorSalida);
                correo.ConfigurarCorreoTarjeta(correos.Correos[i]);
                correos.Correos[i].identificador = i;
                correos.Correos[i].Publicado = true;
            }
            if (correos.Correos[i] != null && correos.Correos[i].Visibilidad && correos.Correos[i].Publicado == false && correos.Correos[i].EstadoCorreo != EstadoCorreo.PorEnviar)
            {
                CorreoTarjeta correo = Instantiate(correoTarjetaPrefab, correoContenedorEntrada);
                correo.ConfigurarCorreoTarjeta(correos.Correos[i]);
                correos.Correos[i].identificador = i;
                correos.Correos[i].Publicado = true;
            }
            
        }
    }

    public void CargarCorreoConID(int id) 
    {
        CorreoTarjeta correo = Instantiate(correoTarjetaPrefab, correoContenedorEntrada);
        correo.ConfigurarCorreoTarjeta(correos.Correos[id]);
        TareaManager.Instance.CargarTareaConID(CorreoSeleccionado.IdTarea);
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

    public void CambiaEstado() 
    {
        CorreoSeleccionado.EstadoCorreo = EstadoCorreo.Enviado;
        MostrarCorreo(CorreoSeleccionado);
        panelBotonesReport.SetActive(false);
        panelInfo.SetActive(false);
        panelInfo.SetActive(true) ;
        
    }
    //Se deja como variable 11 para el dialogo especifico para reuniones post correo
    public void ActivaDialogoPostCorreo() 
    {
        DialogoMedianoManager.GetInstance().ModificarVariablePostCorreo(CorreoSeleccionado.NombreVariableInkRemitente);
        //TareaManager.Instance.CargarTareaConID(CorreoSeleccionado.IdTarea);
        CambiaEstado();
        CargarCorreoConID(CorreoSeleccionado.IDCorreoRespuesta);
        
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
