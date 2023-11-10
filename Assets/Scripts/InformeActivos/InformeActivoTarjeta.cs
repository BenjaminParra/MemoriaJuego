using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformeActivoTarjeta : MonoBehaviour
{
    public ActivoBase ActivoCargado { get; private set; }


    public void ConfigurarActivoTarjeta(ActivoBase activo)
    {
        ActivoCargado = activo;
    }
    public void SeleccionarActivo()
    {
        InformeActivosManager.Instance.MostrarActivo(ActivoCargado);
        UIManager.Instance.AbrirPanelArgumentosActivoInforme();
    }
}
