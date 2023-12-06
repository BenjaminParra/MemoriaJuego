using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computador : Singleton<Computador>
{

    [SerializeField] private int numeroDeSlots;

    public int NumeroDeSlots => numeroDeSlots;

    [Header("Iconos")]
    [SerializeField] private ComputadorItem[] itemsComputador;

    [Header("Prederteminados")]
    [SerializeField] private ComputadorItem[] appsDeterminadas;

    public ComputadorItem[] ItemsComputador => itemsComputador;
    public ComputadorItem[] AppsDeterminadas => appsDeterminadas;

    private void Start()
    {
        itemsComputador = new ComputadorItem[numeroDeSlots];
    }

    private void AbrirSlot(int index) 
    {
        if (itemsComputador[index] == null) 
        {
            return;
        }

        if (itemsComputador[index].AbrirItem()) 
        {
            return;
        }
    }

    public void AñadirItemEnSlotDisponible(ComputadorItem item) 
    {
        for (int i = 0; i < itemsComputador.Length; i++)
        {
            if (itemsComputador[i] == null)
            {
                itemsComputador[i] = item.CopiarItem();
                ComputadorUI.Instance.DibujarItemEnInventario(item, i);
                return;
            }
        }
    }

    #region Eventos

    private void SlotInteraccionRespuestaApp(TipoDeInteraccionSlot tipo, int index)
    {
        switch (tipo) 
        {
            case TipoDeInteraccionSlot.Abrir:
                AbrirSlot(index);
                break;
        }
    }
    private void OnEnable()
    {
        ComputadorSlot.EventoSlotInteraccionApp += SlotInteraccionRespuestaApp;
    }

   

    private void OnDisable()
    {
        ComputadorSlot.EventoSlotInteraccionApp -= SlotInteraccionRespuestaApp;
    }

    #endregion
}
