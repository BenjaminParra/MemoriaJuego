using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

   // [SerializeField] private TextMeshProUGUI controlCosto;
    //[SerializeField] private TextMeshProUGUI cantidadPorComprar;


    [Header("UI proceso")]
    [SerializeField] private Image iconoCorrectoProceso;
    [SerializeField] private Image iconoIncorrectoProceso;
    [SerializeField] private TextMeshProUGUI descripcionProceso;

    [Header("UI persona")]
    [SerializeField] private Image iconoCorrectoPersona;
    [SerializeField] private Image iconoIncorrectoPersona;
    [SerializeField] private TextMeshProUGUI descripcionPersona;

    [Header("UI tecnologia")]
    [SerializeField] private Image iconoCorrectoTecnologia;
    [SerializeField] private Image iconoIncorrectoTecnologia;
    [SerializeField] private TextMeshProUGUI descripcionTecnologia;


    [SerializeField] private Button botonInicio;


    public ControlVenta ControlCargado { get; set; }

    private int cantidad;
    private int costoInicial;
    private int costoActual;
    private void Update()
    {
        // cantidadPorComprar.text = cantidad.ToString();
        //controlCosto.text = costoActual.ToString();
        //Esto debe aplicarse así o sino no se actualiza
        //bool tiempoFinalizado = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(tarjetita.TareaCargada.VariableInkTiempoFinalizado)).value;
        if (ControlCargado.Control.ValorVariableInkPersona)
        {
            iconoCorrectoPersona.enabled = true;
            iconoIncorrectoPersona.enabled = false;
        }
        if (ControlCargado.Control.ValorVariableInkProceso)
        {
            iconoCorrectoProceso.enabled = true;
            iconoIncorrectoProceso.enabled = false;
        }
        if (ControlCargado.Control.ValorVariableInkTecnologia)
        {
            iconoCorrectoTecnologia.enabled = true;
            iconoIncorrectoTecnologia.enabled = false;
        }

        CambiaEstadoProceso(ControlCargado.Control.NombreVariableInkPersona);
        CambiaEstadoProceso(ControlCargado.Control.NombreVariableInkProceso);
        CambiaEstadoProceso(ControlCargado.Control.NombreVariableInkTecnologia);
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
        controlVenta.Control.inicioControl = false;
        iconoIncorrectoPersona.enabled = true;
        iconoIncorrectoProceso.enabled = true;
        iconoIncorrectoTecnologia.enabled = true;
        iconoCorrectoPersona.enabled = false;
        iconoCorrectoProceso.enabled = false;
        iconoCorrectoTecnologia.enabled = false;

        descripcionPersona.text = controlVenta.Control.DescripcionPersona.ToString();
        descripcionProceso.text = controlVenta.Control.DescripcionProceso.ToString();
        descripcionTecnologia.text = controlVenta.Control.DescripcionTecnologia.ToString();
        descripcionControl.text = controlVenta.Control.Descripcion;

        //controlCosto.text = controlVenta.Costo.ToString();
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

    public void IniciarControl() 
    {
        DialogoMedianoManager.GetInstance().ModificarVariable(ControlCargado.Control.nombreVariableInicioControl);
        ControlCargado.Control.inicioControl = true;
        botonInicio.interactable = false;
        CorreoManager.Instance.CargarCorreoBandejaSalida(ControlCargado.Control.IdCorreo);
    }

    public void CambiaEstadoProceso(string nombreVariable)
    {
        if (((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(nombreVariable)).value)
        {
            if (nombreVariable.Equals(ControlCargado.Control.NombreVariableInkPersona))
            {
                ControlCargado.Control.ValorVariableInkPersona = true;
            }
            if (nombreVariable.Equals(ControlCargado.Control.NombreVariableInkProceso))
            {
                ControlCargado.Control.ValorVariableInkProceso = true;
            }
            if (nombreVariable.Equals(ControlCargado.Control.NombreVariableInkTecnologia))
            {
                ControlCargado.Control.ValorVariableInkTecnologia = true;
            }
        }
    }
}
