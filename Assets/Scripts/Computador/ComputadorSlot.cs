using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipoDeInteraccionSlot
{
    Click,
    Abrir
}

public class ComputadorSlot : MonoBehaviour
{
    public static Action<TipoDeInteraccionSlot, int> EventoSlotInteraccionApp;

    public int Index { get; set; }
    public Image icono;

    // Start is called before the first frame update
    void Start()
    {
        icono = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClickSlot() 
    {
        EventoSlotInteraccionApp?.Invoke(TipoDeInteraccionSlot.Click, Index);
    }

    public void AbrirSlot() 
    {
        if (Computador.Instance.ItemsComputador[Index] != null)
        {
            EventoSlotInteraccionApp?.Invoke(TipoDeInteraccionSlot.Abrir, Index);
        }
    }
}
