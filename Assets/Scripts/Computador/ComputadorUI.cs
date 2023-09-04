using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputadorUI : MonoBehaviour
{
    [SerializeField] private ComputadorSlot iconoPrefab;
    [SerializeField] private Transform contenedor;

    List<ComputadorSlot> iconosDisponibles = new List<ComputadorSlot>();

    void Start()
    {
        InicializarInventario();
    }

    private void InicializarInventario() 
    {
        for (int i = 0; i < Computador.Instance.NumeroDeSlots; i++)
        {
            
            if (Computador.Instance.ItemsComputador[i] != null)
            {
                ComputadorSlot nuevoIcono = Instantiate(iconoPrefab, contenedor);
                nuevoIcono.Index = i;
                nuevoIcono.icono.sprite = Computador.Instance.ItemsComputador[i].Icono;
                iconosDisponibles.Add(nuevoIcono);
            }
            
            
        }
    }

    
}
