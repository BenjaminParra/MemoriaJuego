using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App Snipeit")]
public class AppSnipeIt : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirCerrarPanelSnipeIt();
        return true;
    }

}
