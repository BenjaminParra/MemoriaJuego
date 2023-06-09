using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AmenazaLista))]
public class ListaAmenazasEditor : Editor
{
    public AmenazaLista amenazaListaTarget => target as AmenazaLista;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Resetear Valores"))
        {
            amenazaListaTarget.ResetearValores();
        }
    }
}
