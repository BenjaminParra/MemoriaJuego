using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntesItemManager : Singleton<ApuntesItemManager>
{

    [Header("Config")]
    [SerializeField] private ApunteTarjeta apunteTarjetaPrefab;
    [SerializeField] private Transform apunteContenedor;

    [Header("apuntes")]
    [SerializeField] private ApuntesItemLista apuntes;



    private void Start()
    {
        //CargarApuntesInicialmente();
    }

    public void CargarApuntesInicialmente() 
    {
        for (int i = 0; i < apuntes.Apuntes.Count; i++)
        {
            if (apuntes.Apuntes[i] != null)
            {
                ApunteTarjeta apunte = Instantiate(apunteTarjetaPrefab, apunteContenedor);
                apunte.ConfigurarApunteTarjeta(apuntes.Apuntes[i]);
                
                
            }

        }
    }

    public void CargarApunteConId(int id) 
    {
        ApunteTarjeta apunte = Instantiate(apunteTarjetaPrefab, apunteContenedor);
        apunte.ConfigurarApunteTarjeta(apuntes.Apuntes[id]);
    }

    
}
