using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LicenciaSnipeItTarjeta : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image licenciaIcono;
    [SerializeField] private TextMeshProUGUI licenciaNombre;
    [SerializeField] private TextMeshProUGUI licenciaKeyProduct;
    [SerializeField] private TextMeshProUGUI licenciaFechaExpiracion;
    [SerializeField] private TextMeshProUGUI licenciaCorreoAsociado;
    [SerializeField] private TextMeshProUGUI licenciaNombreAsociado;
    [SerializeField] private TextMeshProUGUI licenciaProveedor;


    public LicenciaSnipeIt LicenciaSnipeItCargado { get; private set; }
    public void ConfigurarLicenciaSnipeItTarjeta(LicenciaSnipeIt licencia)
    {
        LicenciaSnipeItCargado = licencia;
        licenciaIcono.sprite = licencia.Icono;
        licenciaNombre.text = licencia.Nombre;
        licenciaKeyProduct.text = licencia.KeyProduct;
        licenciaFechaExpiracion.text = licencia.FechaExpiracion;
        licenciaCorreoAsociado.text = licencia.LicenciaAlCorreo;
        licenciaNombreAsociado.text = licencia.LicenciaAlNombre;
        licenciaProveedor.text = licencia.Proveedor;
    }
}
