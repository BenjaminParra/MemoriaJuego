using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformeActivosManager : MonoBehaviour
{
    [Header("Lista de Activos")]
    [SerializeField] private ActivosLista activos;

    [Header("Servidores")]
    [SerializeField] private Toggle toggleServidores;
    [SerializeField] private string servidoresInforme; //nombre de la variable del ink file 
    [SerializeField] private TextMeshProUGUI servidoresCantidadPistas;


    [Header("ListadoClientes")]
    [SerializeField] private Toggle toggleListadoClientes;
    [SerializeField] private string listadoClientesInforme; //nombre de la variable del ink file 
    [SerializeField] private TextMeshProUGUI listadoClientesCantidadPistas;

    [Header("Ink Json File")]
    [SerializeField] private TextAsset variablesInkJsonFile;

    [Header("botonEnviar")]
    [SerializeField] private Button boton;

    private DialogueVariables dialogueVariables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizaUIActivos();
    }



    public void EnviarInformeActivos() 
    {
        
        if (toggleServidores.isOn) 
        {
            DialogoMedianoManager.GetInstance().ModificarVariable(servidoresInforme);
        }
        if (toggleListadoClientes.isOn)
        {
            DialogoMedianoManager.GetInstance().ModificarVariable(listadoClientesInforme);
        }

        UIManager.Instance.AbrirCerrarPanelConfirmacionActivoInforme();

        toggleListadoClientes.enabled = false; toggleServidores.enabled = false;
        boton.enabled = false;
    }

    private void ActualizaUIActivos() 
    {
        servidoresCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[0])}/{CuentaPistasTotal(activos.Activos[0])}";
            
        listadoClientesCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[1])}/{CuentaPistasTotal(activos.Activos[1])}";
    }

    private int CuentaPistasEncontradas(ActivoBase activo) 
    {
        int pistasEncontradas = 0;

        for (int i = 0; i < activo.variables_pistas_bool.Length; i++)
        {
            bool variable_bool = false;
            if (variable_bool = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(activo.variables_pistas_bool[i])).value)
            {
                pistasEncontradas++;
            }
        }

        return pistasEncontradas;

    }

    private int CuentaPistasTotal(ActivoBase activo) 
    {
        return activo.variables_pistas_string.Count();
    }
}
