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
}
