using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletManager : Singleton<WalletManager>
{

    [Header("Wallet_UI")]
    [SerializeField] private TextMeshProUGUI monedasTMP;
    [SerializeField] private TextMeshProUGUI bonificacionTMP;
    [SerializeField] private TextMeshProUGUI totalTMP;

    [Header("Variables ink")]
    [SerializeField] private string bonificacionVariableInk;
    // Start is called before the first frame update


    private void Start()
    {
        ActualizaNumeros();
    }


    public void ActualizaNumeros() 
    {
        monedasTMP.text = MonedasManager.Instance.MonedasTotales.ToString();
        bonificacionTMP.text = ((Ink.Runtime.FloatValue)DialogoMedianoManager.GetInstance().GetVariableState(bonificacionVariableInk)).value.ToString();
        totalTMP.text = $"Total: {(MonedasManager.Instance.MonedasTotales * ((Ink.Runtime.FloatValue)DialogoMedianoManager.GetInstance().GetVariableState(bonificacionVariableInk)).value)}"; 

    }
}
