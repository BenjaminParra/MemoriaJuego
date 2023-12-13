using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Apps/App ServiceNow")]
public class AppServiceNow : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirCerrarPanelServiceNow();
        return true;
    }
}
