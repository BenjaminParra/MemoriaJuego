using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApunteTarjeta : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image npcIcono;
    [SerializeField] private TextMeshProUGUI npcNombre;
    [SerializeField] private TextMeshProUGUI npcPista;


    public ApunteItem ApunteCargado { get; private set; }

    
    public void ConfigurarApunteTarjeta(ApunteItem apunte) 
    {   
        ApunteCargado = apunte;

        bool conversado = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(ApunteCargado.conversado)).value;
        bool obtuvoPista = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(ApunteCargado.conversado)).value;
        string pistaInk = ((Ink.Runtime.StringValue)DialogoMedianoManager.GetInstance().GetVariableState(ApunteCargado.pista)).value;
        npcIcono.sprite = apunte.iconoNPC;
        npcNombre.text = apunte.nombreNPC;
        npcPista.text = apunte.pistaObtenidaString;
        ApunteCargado.conversadoBool = conversado;
        ApunteCargado.pistaObtenidaBool = obtuvoPista;
        ApunteCargado.pistaObtenidaString = pistaInk;
    }

    public void ActualizarApunte() 
    {
        bool conversado = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(ApunteCargado.conversado)).value;
        bool obtuvoPista = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(ApunteCargado.conversado)).value;
        string pistaInk = ((Ink.Runtime.StringValue)DialogoMedianoManager.GetInstance().GetVariableState(ApunteCargado.pista)).value;

        ApunteCargado.conversadoBool = conversado;
        ApunteCargado.pistaObtenidaBool = obtuvoPista;
        ApunteCargado.pista = pistaInk;
    }

}
