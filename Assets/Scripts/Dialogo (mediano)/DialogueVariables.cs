using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;
public class DialogueVariables
{

    private Dictionary<string, Ink.Runtime.Object> variables;

    //Como el archivo globals es un include no se compila por si solo, por ende se utiliza esta funcion para que se compile 
    public DialogueVariables(string direccionArchivoGlobals) 
    {
        string inkFileContents = File.ReadAllText(direccionArchivoGlobals);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVariablesStory = compiler.Compile();


        //inicializamos el diccionario

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string nombre in globalVariablesStory.variablesState) 
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(nombre);
            variables.Add(nombre, value);
            Debug.Log("Se inicializó la variable global dialogue: "+ nombre + " = " + value);
        }

    }

    public void StartListening(Story story) 
    {
        //debe ir antes del metodo listener
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story) 
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    private void VariableChanged(string nombre, Ink.Runtime.Object value) 
    {
        //solo almacenar variables que han sido inicializadas desde el archivo globals ink
        //Debug.Log("La variable cambió: " + nombre + " = " + value);
        if (variables.ContainsKey(nombre))
        {
            variables.Remove(nombre);
            variables.Add(nombre, value);

        }
    }

    private void VariablesToStory(Story story) 
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables) 
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }

    }

}
