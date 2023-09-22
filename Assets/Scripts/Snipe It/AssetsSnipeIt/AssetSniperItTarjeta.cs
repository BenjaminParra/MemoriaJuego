using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssetSniperItTarjeta : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image assetIcono;
    [SerializeField] private TextMeshProUGUI assetNombre;
    [SerializeField] private TextMeshProUGUI assetNumeroSerie;
    [SerializeField] private TextMeshProUGUI assetModelo;
    [SerializeField] private TextMeshProUGUI assetUbicacion;


    public AssetSnipeIt AssetSnipeItCargado { get; private set; }
    public void ConfigurarAssetSnipeItTarjeta(AssetSnipeIt asset)
    {
        AssetSnipeItCargado = asset;
        assetIcono.sprite = asset.Icono;
        assetNombre.text = asset.Nombre;
        assetNumeroSerie.text = asset.NumeroSerie;
        assetModelo.text = asset.Modelo;
        assetUbicacion.text = asset.Ubicacion;
    }

    /*
    public void SeleccionarReceta()
    {
        CraftingManager.Instance.MostrarReceta(RecetaCargada);
        UIManager.Instance.AbrirCerrarPanelCraftingInformacion(true);
    }*/
}
