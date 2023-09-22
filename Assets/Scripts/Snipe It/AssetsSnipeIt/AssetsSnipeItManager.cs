using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsSnipeItManager : Singleton<AssetsSnipeItManager>
{
    [Header("Assets")]
    [SerializeField] private AssetSnipeItLista assets;

    [Header("Config")]
    [SerializeField] private AssetSniperItTarjeta assetSniperItTarjetaPrefab;
    [SerializeField] private Transform assetSniperItContenedor;

    [Header("Panel Asset")]

    [SerializeField] private GameObject panelAssets;

    public AssetSnipeIt AssetSnipeItSeleccionado { get; set; }

    private void Start()
    {
        CargarAssets();
    }
    private void CargarAssets()
    {
        for (int i = 0; i < assets.Assets.Length; i++)
        {
            AssetSniperItTarjeta asset = Instantiate(assetSniperItTarjetaPrefab, assetSniperItContenedor);
            asset.ConfigurarAssetSnipeItTarjeta(assets.Assets[i]);
        }
    }

    public void AbrirCerrarPanelAssets() 
    {
        panelAssets.SetActive(!panelAssets.activeSelf);
        LicenciaSnipeItManager.Instance.AbrirCerrarPanelLicencias(false);
    }

    public void AbrirCerrarPanelAssets(bool valor)
    {
        panelAssets.SetActive(valor);
    }
}
