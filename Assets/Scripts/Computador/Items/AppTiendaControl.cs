using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apps/App TiendaControl")]
public class AppTiendaControl : ComputadorItem
{
    public override bool AbrirItem()
    {
        UIManager.Instance.AbrirCerrarPanelTiendaControles();
        return true;
    }
}

