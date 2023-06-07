using System.Collections;
using System.Collections.Generic;
using TMPro;
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


    public Correo CorreoSeleccionado { get; set; }
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

    public void MostrarCorreo(Correo correo) 
    {
        CorreoSeleccionado = correo;
        asuntoTMP.text = correo.AsuntoCorreo;

        iconoRemitente.sprite = correo.IconoRemitente;
        nombreRemitente.text = correo.NombreRemitente;
        correoRemitente.text = correo.CorreoRemitente;

        cuerpoCorreo.text = correo.CuerpoCorreo;

    }
}
