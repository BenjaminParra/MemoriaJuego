using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorreoTarjeta : MonoBehaviour
{
    [SerializeField] private Image correoRemitente;
    [SerializeField] private TextMeshProUGUI correoAsunto;


    public Correo CorreoCargado { get; private set; }
    public void ConfigurarCorreoTarjeta(Correo correo) 
    {
        CorreoCargado = correo;
        correoRemitente.sprite = correo.IconoRemitente;
        correoAsunto.text = correo.AsuntoCorreo;
    }


    public void SeleccionarCorreo() 
    {
        CorreoManager.Instance.MostrarCorreo(CorreoCargado);
        UIManager.Instance.AbrirCerraPanelCorreoInfo(true);
    }

    public void Desactivar(Correo correo) 
    {
        gameObject.SetActive(false);
    }
}
