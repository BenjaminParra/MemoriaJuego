using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ComputadorItem))]
public class ListaAppsEditor : Editor
{
    public ComputadorItem computadorItemTarget => target as ComputadorItem;

    public override void OnInspectorGUI() 
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Resetear Valores"))
        {
            computadorItemTarget.ResetearValores();
        }
    }
}
