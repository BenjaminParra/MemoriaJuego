using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TipoDeInteraccion
{
    Click,
    Usar,
    Equipar,
    Remover

}
public class InventarioSlot : MonoBehaviour
{
    public static Action<TipoDeInteraccion, int> EventoSlotInteraccion;

    [SerializeField] private Image itemIcono;
    [SerializeField] private GameObject fondoCantidad;
    [SerializeField] private TextMeshProUGUI cantidadTMP;
    public int Index { get; set; }


    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void ActualizarSlot(InventarioItem item, int cantidad) 
    {
        itemIcono.sprite = item.icono;
        cantidadTMP.text = cantidad.ToString();
    }

    public void ActivarSlotUI(bool estado) 
    {
        itemIcono.gameObject.SetActive(estado);
        fondoCantidad.SetActive(estado);    
    }

    // de esta forma el boton queda seleccionado cuando se llama este evento
    public void SeleccionarSlot() 
    {
        button.Select();
    }
    public void ClickSlot() 
    {
        EventoSlotInteraccion?.Invoke(TipoDeInteraccion.Click,Index);

        //mover Item
        if (InventarioUI.Instance.IndexSlotInicialPorMover != -1)
        {
            if (InventarioUI.Instance.IndexSlotInicialPorMover != Index)
            {
                //mover
                Inventario.Instance.MoverItem(InventarioUI.Instance.IndexSlotInicialPorMover,Index);
            }
        }
    }

    public void SlotUsarItem() 
    {
        if (Inventario.Instance.ItemsInventario[Index] != null)
        {
            EventoSlotInteraccion?.Invoke(TipoDeInteraccion.Usar, Index);
        }
    }

    public void SlotEquiparItem() 
    {
        if (Inventario.Instance.ItemsInventario[Index] != null)
        {
            EventoSlotInteraccion?.Invoke(TipoDeInteraccion.Equipar, Index);
        }
    }

    public void SlotRemoverItem()
    {
        if (Inventario.Instance.ItemsInventario[Index] != null)
        {
            EventoSlotInteraccion?.Invoke(TipoDeInteraccion.Remover, Index);
        }
    }
}
