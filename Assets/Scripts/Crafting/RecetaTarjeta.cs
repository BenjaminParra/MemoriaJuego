using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecetaTarjeta : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image recetaIcono;
    [SerializeField] private TextMeshProUGUI recetaNombre;


    public Receta RecetaCargada { get; private set; }
    public void ConfigurarRecetaTarjeta(Receta receta) 
    {
        RecetaCargada = receta;
        recetaIcono.sprite = receta.ItemResultado.icono;
        recetaNombre.text = receta.ItemResultado.nombre;
    }

    public void SeleccionarReceta() 
    {
        CraftingManager.Instance.MostrarReceta(RecetaCargada);
        UIManager.Instance.AbrirCerrarPanelCraftingInformacion(true);
    }
}
