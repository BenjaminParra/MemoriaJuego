using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ApuntesItemLista))]
public class ListaApuntesEditor : Editor
{
    public ApuntesItemLista ApuntesTarget => target as ApuntesItemLista;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Resetear Valores"))
        {
            ApuntesTarget.ResetearValores();
        }
    }
}
