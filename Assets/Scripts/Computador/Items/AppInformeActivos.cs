using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App InformeActivos")]
public class AppInformeActivos : ComputadorItem
{
    public override bool AbrirItem()
    {
       UIManager.Instance.AbrirCerrarPanelInformeActivo();
        return true;
    }
}
