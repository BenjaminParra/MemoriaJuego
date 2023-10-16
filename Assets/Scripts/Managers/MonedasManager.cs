using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedasManager : Singleton<MonedasManager>
{
    [SerializeField] private int monedasTest;
    [Header("Nombre de variables ink relacionadas al presupuesto")]
    //Variable perteneciente a ink  que contiene valores booleanos que permiten saber si el presupuesto fue asignado o no 
    [SerializeField] private string variablesInkPresupuestoAsignadoBool;
    //Variable perteneciente a ink que contiene la cantidad de presupuesto asignado por el jefe
    [SerializeField] private string nombreVariableInkCantidadPresupuesto;
    public int MonedasTotales { get; set; }


    private bool fueAsignado;

    private bool actualizoBonificacion;

    private string KEY_MONEDAS = "MIJUEGO_MONEDAS";

    private void Start()
    {
        //despues se borra
        PlayerPrefs.DeleteKey(KEY_MONEDAS);
        CargarMonedas();
    }

    private void Update()
    {
        if (!fueAsignado) 
        {
            AsignarPresupuesto();
        }
        
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

    public void AsignarPresupuesto() 
    {
        bool asignado = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(variablesInkPresupuestoAsignadoBool)).value;
        if (asignado) 
        {
            MonedasTotales = ((Ink.Runtime.IntValue)DialogoMedianoManager.GetInstance().GetVariableState(nombreVariableInkCantidadPresupuesto)).value;
            PlayerPrefs.SetInt(KEY_MONEDAS,MonedasTotales);
            PlayerPrefs.Save();
            fueAsignado = true;
        }
    }
}
