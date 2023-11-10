using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlTienda : MonoBehaviour
{
    [Header("UI_Config")]
    [SerializeField] private TextMeshProUGUI idControl;
    [SerializeField] private TextMeshProUGUI nombreControl;

    [SerializeField] private TextMeshProUGUI idSalvaguarda;
    [SerializeField] private TextMeshProUGUI nombreSalvaguarda;

    [SerializeField] private TextMeshProUGUI tipoActivo;
    [SerializeField] private TextMeshProUGUI funcionSeguridad;

    [SerializeField] private TextMeshProUGUI descripcionControl;

    [SerializeField] private TextMeshProUGUI controlCosto;
    [SerializeField] private TextMeshProUGUI cantidadPorComprar;

    public ControlVenta ControlCargado { get; set; }

    private int cantidad;
    private int costoInicial;
    private int costoActual;
    private void Update()
    {
        cantidadPorComprar.text = cantidad.ToString();
        controlCosto.text = costoActual.ToString();
    }

    public void ConfigurarControlEnVenta(ControlVenta controlVenta) 
    {
        ControlCargado = controlVenta;
        idControl.text = controlVenta.Control.IdControl;
        nombreControl.text = controlVenta.Control.NombreControl;

        idSalvaguarda.text = controlVenta.Control.IdSalvaguardas;
        nombreSalvaguarda.text = controlVenta.Control.NombreSalvaguardas;

        tipoActivo.text = controlVenta.Control.TipoActivo.ToString();
        funcionSeguridad.text = controlVenta.Control.FuncionSeguridad.ToString();

        descripcionControl.text = controlVenta.Control.Descripcion;

        controlCosto.text = controlVenta.Costo.ToString();
        cantidad = 1;
        costoInicial = controlVenta.Costo;
        costoActual = controlVenta.Costo;
    }

    public void SumarControlPorComprar() 
    {
        int costoDeCompra = costoInicial * (cantidad + 1);
        if (MonedasManager.Instance.MonedasTotales >= costoDeCompra && cantidad < 1) 
        {
            cantidad += 1;
            costoActual = costoInicial * cantidad;
        }
    }

    public void RestarContolPorComprar() 
    {
        if (cantidad == 0) 
        {
            return;
        }
        cantidad -= 1;
        costoActual = costoInicial * cantidad;
    }
}
