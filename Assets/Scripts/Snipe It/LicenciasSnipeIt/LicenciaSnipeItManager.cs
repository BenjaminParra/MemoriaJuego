using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenciaSnipeItManager : Singleton<LicenciaSnipeItManager>
{
    [Header("Assets")]
    [SerializeField] private LicenciaSnipeItLista licencias;

    [Header("Config")]
    [SerializeField] private LicenciaSnipeItTarjeta licenciaSniperItTarjetaPrefab;
    [SerializeField] private Transform licenciaSniperItContenedor;

    [Header("Panel Licencias")]

    [SerializeField] private GameObject panelLicencias;

    public LicenciaSnipeIt LicenciaSnipeItSeleccionado { get; set; }

    private void Start()
    {
        CargarAssets();
    }
    private void CargarAssets()
    {
        for (int i = 0; i < licencias.Licencias.Length; i++)
        {
            LicenciaSnipeItTarjeta licencia = Instantiate(licenciaSniperItTarjetaPrefab, licenciaSniperItContenedor);
            licencia.ConfigurarLicenciaSnipeItTarjeta(licencias.Licencias[i]);
        }
    }

    public void AbrirCerrarPanelLicencias()
    {
        panelLicencias.SetActive(!panelLicencias.activeSelf);
        AssetsSnipeItManager.Instance.AbrirCerrarPanelAssets(false);
    }

    public void AbrirCerrarPanelLicencias(bool valor) 
    {
        panelLicencias.SetActive(valor);
    }
}
