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

    public ComputadorItem[] ItemsComputador => itemsComputador;

    private void Start()
    {
        //itemsComputador = new ComputadorItem[numeroDeSlots];
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
