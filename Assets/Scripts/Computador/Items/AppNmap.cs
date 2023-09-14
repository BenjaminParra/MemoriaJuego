using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App Nmap")]
public class AppNmap : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirCerrarPanelCmd();
        return true;
    }
}
