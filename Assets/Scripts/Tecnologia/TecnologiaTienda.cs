using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TecnologiaTienda : MonoBehaviour
{
    [Header("UI_Config")]
    [SerializeField] private Image iconoTecnologia;
    [SerializeField] private TextMeshProUGUI nombreTecnologia;
    [SerializeField] private TextMeshProUGUI costoTecnologia;
    [SerializeField] private TextMeshProUGUI descripcionTecnologia;
    [SerializeField] private TextMeshProUGUI controlAsociado;
    [SerializeField] private TextMeshProUGUI tiempoAsociadoAprendizaje;
    [SerializeField] private TextMeshProUGUI soporte;
    [SerializeField] private TextMeshProUGUI actualizaciones;


    public TecnologiaVenta TecnologiaCargada { get; set; }

    public void ConfigurarTecnologiaEnVenta(TecnologiaVenta tecnologiaVenta) 
    {
        TecnologiaCargada = tecnologiaVenta;
        nombreTecnologia.text = tecnologiaVenta.Tecnologia.Nombre;
        costoTecnologia.text = tecnologiaVenta.Costo.ToString();
        descripcionTecnologia.text = tecnologiaVenta.Tecnologia.DescripcionTecnologia;
        controlAsociado.text = $"Control Asociado {tecnologiaVenta.Tecnologia.SalvaguardasAsociado}" ;
        tiempoAsociadoAprendizaje.text = $"El tiempo necesario para instalación y aprendizaje es de {tecnologiaVenta.Tecnologia.TiempoNecesarioEstudio} hrs";
        soporte.text = EntregaTextoSoporte(tecnologiaVenta);
        actualizaciones.text = EntregaTextoActualizaciones(tecnologiaVenta);
        iconoTecnologia.sprite = tecnologiaVenta.Tecnologia.Icono;

    }

    public string EntregaTextoSoporte(TecnologiaVenta tecnologiaVenta) 
    {
        string respuesta = "";

        if (tecnologiaVenta.Tecnologia.Soporte == Soporte.Nulo)
        {
            respuesta = "La tecnología no cuenta con soporte, solo un documento con problemas estandar.";
        }
        if (tecnologiaVenta.Tecnologia.Soporte == Soporte.Personalizado)
        {
            respuesta = "La tecnología cuenta con un soporte personalizado para cualquiera de las dudas o problemas.";
        }

        if (tecnologiaVenta.Tecnologia.Soporte == Soporte.Instalacion)
        {
            respuesta = "La tecnología cuenta con soporte solo durante su instalación.";
        }
        return respuesta;
    }

    public string EntregaTextoActualizaciones(TecnologiaVenta tecnologiaVenta)
    {
        string respuesta = "";

        if (tecnologiaVenta.Tecnologia.Actualizaciones == Actualizaciones.Desactualizado)
        {
            respuesta = "La tecnología no cuenta con actualizaciones.";
        }
        if (tecnologiaVenta.Tecnologia.Actualizaciones == Actualizaciones.Periodicamente)
        {
            respuesta = "La tecnología cuenta con actualizaciones periodicamente.";
        }

        if (tecnologiaVenta.Tecnologia.Actualizaciones == Actualizaciones.Desconocido)
        {
            respuesta = "La tecnología cuenta con actualizaciones, pero se realizan de vez en cuando.";
        }
        return respuesta;
    }
}
