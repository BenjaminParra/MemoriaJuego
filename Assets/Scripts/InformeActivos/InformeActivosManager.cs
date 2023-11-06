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

    [Header("Documentacion de Proyectos")]
    [SerializeField] private Toggle toggleDocumentacionProyectos;
    [SerializeField] private string documentacionProyectosInforme; //nombre de la variable del ink file 
    [SerializeField] private TextMeshProUGUI documentacionProyectosCantidadPistas;

    [Header("Información financiera")]
    [SerializeField] private Toggle toggleInformacionFinanciera;
    [SerializeField] private string informacionFinancieraInforme; //nombre de la variable del ink file 
    [SerializeField] private TextMeshProUGUI informacionFinancieraCantidadPistas;

    [Header("Servicio Web")]
    [SerializeField] private Toggle toggleServicioWeb;
    [SerializeField] private string servicioWebInforme; //nombre de la variable del ink file 
    [SerializeField] private TextMeshProUGUI servicioWebCantidadPistas;

    [Header("Ink Json File")]
    [SerializeField] private TextAsset variablesInkJsonFile;

    [Header("botonEnviar")]
    [SerializeField] private Button boton;

    private bool informeEnviado = false;

    private DialogueVariables dialogueVariables;
    // Start is called before the first frame update
    void Start()
    {
        boton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizaUIActivos();
        if (informeEnviado == false) 
        {
            HabilitaBotonEnviar();
            DeshabilitaBotonEnviar();
        }

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

        if (toggleServicioWeb.isOn) 
        {
            DialogoMedianoManager.GetInstance().ModificarVariable(servicioWebInforme);
        }

        if (toggleDocumentacionProyectos.isOn)
        {
            DialogoMedianoManager.GetInstance().ModificarVariable(documentacionProyectosInforme);

        }

        if (toggleInformacionFinanciera.isOn) 
        {
            DialogoMedianoManager.GetInstance().ModificarVariable(informacionFinancieraInforme);
        }

        
        UIManager.Instance.AbrirCerrarPanelConfirmacionActivoInforme();
        informeEnviado = true;
        toggleListadoClientes.enabled = false; toggleServidores.enabled = false;
        boton.enabled = false;
    }

    private void HabilitaBotonEnviar() 
    {
        if (toggleDocumentacionProyectos.isOn || toggleInformacionFinanciera.isOn || toggleListadoClientes.isOn || toggleServicioWeb.isOn || toggleServidores.isOn) 
        {
            boton.enabled = true;
        }
    }
    private void DeshabilitaBotonEnviar() 
    {
        if (!toggleDocumentacionProyectos.isOn && !toggleInformacionFinanciera.isOn && !toggleListadoClientes.isOn && !toggleServicioWeb.isOn && !toggleServidores.isOn)
        {
            boton.enabled = false;
        }
    }

    private void ActualizaUIActivos() 
    {
        servidoresCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[0])}/{CuentaPistasTotal(activos.Activos[0])}";
            
        listadoClientesCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[1])}/{CuentaPistasTotal(activos.Activos[1])}";

        documentacionProyectosCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[2])}/{CuentaPistasTotal(activos.Activos[2])}";

        informacionFinancieraCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[3])}/{CuentaPistasTotal(activos.Activos[3])}";

        servicioWebCantidadPistas.text = $"{CuentaPistasEncontradas(activos.Activos[4])}/{CuentaPistasTotal(activos.Activos[4])}";
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
