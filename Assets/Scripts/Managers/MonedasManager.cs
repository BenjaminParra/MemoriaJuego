using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedasManager : Singleton<MonedasManager>
{
    [SerializeField] private int monedasTest;
    public int MonedasTotales { get; set; }

    private string KEY_MONEDAS = "MIJUEGO_MONEDAS";

    private void Start()
    {
        //despues se borra
        PlayerPrefs.DeleteKey(KEY_MONEDAS);
        CargarMonedas();
    }

    private void CargarMonedas() 
    {
        MonedasTotales = PlayerPrefs.GetInt(KEY_MONEDAS,monedasTest);
    }
    public void AñadirMonedas(int cantidadMonedas) 
    {
        MonedasTotales += cantidadMonedas;
        PlayerPrefs.SetInt(KEY_MONEDAS, MonedasTotales);
        PlayerPrefs.Save(); 
    }

    public void RemoverMonedas(int cantidadMonedas) 
    {
        if (cantidadMonedas > MonedasTotales)
        {
            return;
        }
        MonedasTotales -= cantidadMonedas;
        PlayerPrefs.SetInt(KEY_MONEDAS, MonedasTotales);
        PlayerPrefs.Save();
    }
}
