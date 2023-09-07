using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App Apuntes")]
public class AppApuntes : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirCerrarPanelApuntes(); 
        return true;
    }
}
