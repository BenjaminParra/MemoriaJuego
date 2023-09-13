using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App Activos")]
public class AppActivos : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirPanelActivos();
        return true;
    }
    

}
