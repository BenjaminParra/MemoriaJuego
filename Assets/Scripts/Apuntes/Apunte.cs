using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Apunte : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI apunte;
    [SerializeField] private GameObject apunteTarjeta;


    [SerializeField] private string conversadoString;
    [SerializeField] private string obtuvoPistaString;
    [SerializeField] private string pistaString;
    /*
    [Header("Gameobjects")]
    [SerializeField] private GameObject[] apuntes;*/

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool conversado = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(conversadoString)).value;
        bool obtuvoPista = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(obtuvoPistaString)).value;
        string pista = ((Ink.Runtime.StringValue)DialogoMedianoManager.GetInstance().GetVariableState(pistaString)).value;

        ActivadorTarjeta(conversado, pista);
        ModificadorTexto(obtuvoPista, pista);

    }
    public void ActivadorTarjeta(bool verificador, string nuevaPista) 
    {
        Debug.Log("verificador = " + verificador);
        if (verificador) 
        {
            apunteTarjeta.SetActive(true);
            apunte.text = nuevaPista;
        }
    }

    public void ModificadorTexto(bool verificador, string nuevoApunte) 
    {
        if (verificador) 
        {
            apunte.text = nuevoApunte;
        }
    }

    /*
    public void ActivaApuntes(int id) 
    {
        for (int i = 0; i < apuntes.Length; i++) 
        {
            if (id == i)
            {
                apuntes[i].SetActive(true);
                apuntes[i].GetComponent<>
            }
        }
    }*/
}
