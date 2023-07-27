using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivoTarjeta : MonoBehaviour
{
    [SerializeField] private Image activoIcono;
    [SerializeField] private TextMeshProUGUI activoNombre;
    
    public ActivoBase ActivoCargado { get; private set; }

    public void ConfigurarActivoTarjeta(ActivoBase activo) 
    {
        ActivoCargado = activo;
        activoIcono.sprite = activo.iconoActivo;
        activoNombre.text = activo.nombre;
    }

    public void SeleccionarActivo() 
    {
        ActivoManager.Instance.MostrarActivo(ActivoCargado);
        UIManager.Instance.AbrirCerraPanelActivoInfo(true);
    }
}
