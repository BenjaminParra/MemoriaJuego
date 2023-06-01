using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : Singleton<CraftingManager>
{
    [Header("Config")]
    [SerializeField] private RecetaTarjeta recetaTragetaPrefab;
    [SerializeField] private Transform recetaContenedor;

    [Header("Receta Info")]
    [SerializeField] private Image primerMaterialIcono;
    [SerializeField] private Image segundoMaterialIcono;

    [SerializeField] private TextMeshProUGUI primerMaterialNombre;
    [SerializeField] private TextMeshProUGUI segundoMaterialNombre;

    [SerializeField] private TextMeshProUGUI primerMaterialCantidad;
    [SerializeField] private TextMeshProUGUI segundoMaterialCantidad;

    [SerializeField] private TextMeshProUGUI recetaMensaje;
    [SerializeField] private Button botonCraftear;

    [Header("Item Resultado")]
    [SerializeField] private Image itemResultadoIcono;
    [SerializeField] private TextMeshProUGUI itemResultadoNombre;
    [SerializeField] private TextMeshProUGUI itemResultadoDescripcion;


    [Header("Recetas")]
    [SerializeField] private RecetaLista recetas;

    public Receta RecetaSeleccionada { get; set; }

    private void Start()
    {
        CargarRecetas();
    }
    private void CargarRecetas() 
    {
        for (int i = 0; i < recetas.Recetas.Length; i++) 
        {
            RecetaTarjeta receta = Instantiate(recetaTragetaPrefab, recetaContenedor);
            receta.ConfigurarRecetaTarjeta(recetas.Recetas[i]);
        }
    }

    public void MostrarReceta(Receta receta) 
    {
        RecetaSeleccionada = receta;
        primerMaterialIcono.sprite = receta.Item1.icono;
        segundoMaterialIcono.sprite= receta.Item2.icono;

        primerMaterialNombre.text = receta.Item1.nombre;
        segundoMaterialNombre.text= receta.Item2.nombre;

        primerMaterialCantidad.text = $"{Inventario.Instance.ObtenerCantidadDeItems(receta.Item1.ID)}/{receta.Item1CantidadRequerida}";
        segundoMaterialCantidad.text = $"{Inventario.Instance.ObtenerCantidadDeItems(receta.Item2.ID)}/{receta.Item2CantidadRequerida}";
        //ModificarMensaje(receta);
        if (SePuedeCraftear(receta))
        {
            recetaMensaje.text = "RecetaDisponible";
            botonCraftear.interactable = true;
        }
        else 
        {
            recetaMensaje.text = "Necesitas mas materiales";
            botonCraftear.interactable = false;
        }
        itemResultadoIcono.sprite = receta.ItemResultado.icono;
        itemResultadoNombre.text = receta.ItemResultado.nombre;

        itemResultadoDescripcion.text = receta.ItemResultado.DescripcionItemCrafting();


    }


    public bool SePuedeCraftear(Receta receta) 
    {
        if (Inventario.Instance.ObtenerCantidadDeItems(receta.Item1.ID) >= receta.Item1CantidadRequerida
            && Inventario.Instance.ObtenerCantidadDeItems(receta.Item2.ID) >= receta.Item2CantidadRequerida) 
        {
            return true;
        }
        return false;

    }


    public void Craftear()
    {
        for (int i = 0; i < RecetaSeleccionada.Item1CantidadRequerida; i++)
        {
            Inventario.Instance.ConsumirItem(RecetaSeleccionada.Item1.ID);
        }

        for (int i = 0; i < RecetaSeleccionada.Item2CantidadRequerida; i++)
        {
            Inventario.Instance.ConsumirItem(RecetaSeleccionada.Item2.ID);
        }

        Inventario.Instance.AñadirItems(RecetaSeleccionada.ItemResultado, RecetaSeleccionada.ItemResultadoCantidad);
        MostrarReceta(RecetaSeleccionada);
    }

    /*
    private void ModificarMensaje(Receta receta) 
    {
        int cantidadPrimerItemEnInventario = Inventario.Instance.ObtenerCantidadDeItems(receta.Item1.ID);
        int cantidadSegundoItemEnInventario = Inventario.Instance.ObtenerCantidadDeItems(receta.Item2.ID);

        if ((cantidadPrimerItemEnInventario < receta.Item1CantidadRequerida) || (cantidadSegundoItemEnInventario < receta.Item2CantidadRequerida))
        {
            recetaMensaje.text = $"Faltan materiales";
        }
        else 
        {
            recetaMensaje.text = $"¿Deseas craftear {receta.ItemResultado.nombre}?";
        }
    }*/
}
