using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : Singleton<Inventario>
{

    [Header("Items")]
    [SerializeField] private Personaje personaje;
    [SerializeField] private int numeroDeSlots;
    [SerializeField] private InventarioItem[] itemsInventario;

    public Personaje Personaje => personaje;
    public int NumeroDeSlots => numeroDeSlots;
    //propiedad para devolver el array inventario
    public InventarioItem[] ItemsInventario => itemsInventario;

    private void Start()
    {
        itemsInventario = new InventarioItem[numeroDeSlots];
    }

    public void AñadirItems(InventarioItem itemPorAñadir, int cantidad)  //pocion 15 / 15
    {
        if (itemPorAñadir == null)// no / no
        {
            return;
        }
        //item similar en inventario
        List<int> indexes = VerificarExistencias(itemPorAñadir.ID);//null / un islot

        if (itemPorAñadir.EsAcumulable)// si
        {
            if (indexes.Count > 0) //no / si 
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (itemsInventario[indexes[i]].cantidad < itemPorAñadir.AcumulacionMax)// 15 < 50? si
                    {
                        itemsInventario[indexes[i]].cantidad += cantidad; // 15 +15 
                        if (itemsInventario[indexes[i]].cantidad > itemPorAñadir.AcumulacionMax) // 30 > 50? no
                        {
                            int diferencia = itemsInventario[indexes[i]].cantidad - itemPorAñadir.AcumulacionMax; //
                            itemsInventario[indexes[i]].cantidad = itemPorAñadir.AcumulacionMax;
                            AñadirItems(itemPorAñadir, diferencia);
                        }
                        InventarioUI.Instance.DibujarItemEnInventario(itemPorAñadir, itemsInventario[indexes[i]].cantidad, indexes[i]);
                        return;
                    }
                }
            }
        }

        if (cantidad <=0) // no // no
        {
            return;
        }
        if (cantidad > itemPorAñadir.AcumulacionMax) // 15 > 50? no / 30 > 50? no
        {
            AñadirItemEnSlotDisponible(itemPorAñadir, itemPorAñadir.AcumulacionMax);
            cantidad -= itemPorAñadir.AcumulacionMax;
            AñadirItems(itemPorAñadir, cantidad);
        }
        else
        { 
            AñadirItemEnSlotDisponible(itemPorAñadir, cantidad); // 15 / 30
        }

    }

    private List<int> VerificarExistencias(string itemID) 
    {
        List<int> indexesDelItem = new List<int>();
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] != null)
            {
                if (itemsInventario[i].ID == itemID)
                {
                    indexesDelItem.Add(i);
                }

            }
            
        }

        return indexesDelItem;
    }

    public int ObtenerCantidadDeItems(string itemID) 
    {
        List<int> indexes = VerificarExistencias(itemID);
        int cantidaTotal = 0;
        foreach (int index in indexes) 
        {
            if (itemsInventario[index].ID == itemID)
            {
                cantidaTotal += itemsInventario[index].cantidad;
            }
        }
        return cantidaTotal;
    }

    public void ConsumirItem(string itemID) 
    {
        List<int> indexes = VerificarExistencias(itemID);
        if (indexes.Count > 0) 
        {
            //se consumen desde el ultimo slot 
            EliminarItem(indexes[indexes.Count - 1]);
        }
    }
    private void AñadirItemEnSlotDisponible(InventarioItem item, int cantidad) // 15 / 30
    {
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] == null)
            {
                itemsInventario[i] = item.CopiarItem(); //i = 0 item copia cantidad 15/
                itemsInventario[i].cantidad = cantidad;
                InventarioUI.Instance.DibujarItemEnInventario(item, cantidad, i);
                return;

            }
        }
    }

    private void EliminarItem(int index) 
    {
        itemsInventario[index].cantidad--;
        if (itemsInventario[index].cantidad <= 0)
        {
            itemsInventario[index].cantidad = 0;
            itemsInventario[index] = null;
            InventarioUI.Instance.DibujarItemEnInventario(null, 0, index);
        }
        else 
        {
            InventarioUI.Instance.DibujarItemEnInventario(itemsInventario[index], itemsInventario[index].cantidad, index);
        }
    }

    public void MoverItem(int indexInicial, int indexFinal) 
    {
        if (itemsInventario[indexInicial] == null || itemsInventario[indexFinal] != null)
        {
            return;
        }
        else
        {
            //copiar item en slot final
            InventarioItem itemPorMover = itemsInventario[indexInicial].CopiarItem();
            itemsInventario[indexFinal] = itemPorMover;

            InventarioUI.Instance.DibujarItemEnInventario(itemPorMover, itemPorMover.cantidad, indexFinal);

            //borrar item slot inicial

            itemsInventario[indexInicial] = null;
            InventarioUI.Instance.DibujarItemEnInventario(null,0,indexInicial);
        }
    }
    private void UsarItem(int index) 
    {
        
        if (itemsInventario[index].UsarItem())
        {
            EliminarItem(index);
        }
    }

    private void EquiparItem(int index) 
    {
        if (itemsInventario[index] == null)
        {
            return;
        }
        if (itemsInventario[index].tipo != TipoItems.Armas)
        {
            return;
        }
        itemsInventario[index].EquiparItem();
    }

    private void RemoverItem(int index) 
    {
        if (itemsInventario[index] == null)
        {
            return;
        }
        if (itemsInventario[index].tipo != TipoItems.Armas)
        {
            return;
        }
        itemsInventario[index].RemoverItem();

    }
    #region Eventos


    private void SlotInteraccionRespuesta(TipoDeInteraccion tipo, int index)
    {
        switch (tipo)
        {
            case TipoDeInteraccion.Click:
                break;
            case TipoDeInteraccion.Usar:
                UsarItem(index);
                break;
            case TipoDeInteraccion.Equipar:
                EquiparItem(index);
                break;
            case TipoDeInteraccion.Remover:
                RemoverItem(index);
                break;
            default:
                break;
        }
    }
    private void OnEnable()
    {
        InventarioSlot.EventoSlotInteraccion += SlotInteraccionRespuesta;
    }


    private void OnDisable()
    {
        InventarioSlot.EventoSlotInteraccion -= SlotInteraccionRespuesta;
    }
    #endregion

    /*
    private bool EstaLleno(InventarioItem item) 
    {
        bool respuesta = false;
        int contador = 0;
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i].cantidad == item.AcumulacionMax)
            {
                contador += 1;
            }
        }
    }*/

}
