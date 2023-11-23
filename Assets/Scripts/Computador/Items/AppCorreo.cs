using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App Correo")]
public class AppCorreo : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirPanelCorreo();
        return true;
    }
}
