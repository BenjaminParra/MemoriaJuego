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
            amenaza.CrearAmenaza(amenazaPishing.GetComponent<AmenazaMadre>().nombreOriginal,
                amenazaPishing.GetComponent<AmenazaMadre>().estadoOriginal,
                amenazaPishing.GetComponent<AmenazaMadre>().tipoOriginal,
                amenazaPishing.GetComponent<AmenazaMadre>().consejosOriginal,
                amenazaPishing.GetComponent<AmenazaMadre>().controlesRecomendadosOriginal);
            amenazaLista.AñadirAmenaza(amenaza);
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
            amenaza.CrearAmenaza(amenazaPishing.GetComponent<AmenazaMadre>().nombreOriginal,
                Estado.Mitigado,
                amenazaPishing.GetComponent<AmenazaMadre>().tipoOriginal,
                amenazaPishing.GetComponent<AmenazaMadre>().consejosOriginal,
                amenazaPishing.GetComponent<AmenazaMadre>().controlesRecomendadosOriginal);
            amenazaLista.AñadirAmenaza(amenaza);
            panelBotonesReport.SetActive(false);
        }
        else 
        {
            panelBotonesReport.SetActive(false);
            return;
        }
    }

    //agregar a la amenaza madre una cantidad y solo cuando esa cantidad llegue a cero cambiar estado a mitigado
    private bool ExisteAmenazaTipo() 
    {
        for (int i = 0;i< amenazaLista.Amenazas.Count;i++) 
        {
            if (amenazaLista.Amenazas[i].Nombre == "Pishing" && amenazaLista.Amenazas[i].Estado == Estado.Activa)
            {
                return true;
            }
        }
        return false;
    }
}
