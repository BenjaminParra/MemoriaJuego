using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTienda : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image itemIcono;
    [SerializeField] private TextMeshProUGUI itemNombre;
    [SerializeField] private TextMeshProUGUI itemCosto;
    [SerializeField] private TextMeshProUGUI cantidadPorComprar;


    public ItemVenta ItemCargado { get; set; }

    private int cantidad;
    private int costoInicial;
    private int costoActual;

    private void Update()
    {
        cantidadPorComprar.text = cantidad.ToString();
        itemCosto.text = costoActual.ToString();
    }

    public void ConfigurarItemEnVenta(ItemVenta itemVenta) 
    {
        ItemCargado = itemVenta;
        itemIcono.sprite = itemVenta.Item.icono;
        itemNombre.text = itemVenta.Item.nombre;
        itemCosto.text = itemVenta.Costo.ToString();
        cantidad = 1;
        costoInicial = itemVenta.Costo;
        costoActual = itemVenta.Costo;
    }
    public void ComprarItem() 
    {
        if (MonedasManager.Instance.MonedasTotales >= costoActual) 
        {
            Inventario.Instance.AñadirItems(ItemCargado.Item, cantidad);
            MonedasManager.Instance.RemoverMonedas(costoActual);
            cantidad = 1;
            costoActual = costoInicial;
        }
    }

    public void SumarItemPorComprar() 
    {
        int costoDeCompra = costoInicial * (cantidad + 1);
        if (MonedasManager.Instance.MonedasTotales >= costoDeCompra) 
        {
            cantidad++;
            costoActual = costoInicial * cantidad;
        }
    }

    public void RestarItemPorComprar() 
    {
        if (cantidad == 1)
        {
            return;
        }
        cantidad--;
        costoActual = costoInicial * cantidad;
    }
}
