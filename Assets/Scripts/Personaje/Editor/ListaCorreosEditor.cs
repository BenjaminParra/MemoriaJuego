using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CorreoLista))]
public class ListaCorreosEditor : Editor
{
    public CorreoLista correoListaTarget => target as CorreoLista;
    // Start is called before the first frame update

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Resetear Valores"))
        {
            correoListaTarget.ResetearValores();
        }
    }
}

