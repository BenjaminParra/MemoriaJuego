using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteraccionExtraNPC
{
    Quests,
    Tienda,
    Crafting,
    Correo
}
[CreateAssetMenu]
public class NPCDialogo : ScriptableObject
{
    [Header("Info")]
    public string Nombre;
    public Sprite Icono;
    public bool ContieneInteraccionExtra;
    public InteraccionExtraNPC interaccionExtra;


    [Header("Saludo")]

    [TextArea] public string Saludo;

    [Header("Chat")]

    public DialogoTexto[] Conversacion;


    [Header("Despedida")]

    [TextArea] public string Despedida;
}

[Serializable]
public class DialogoTexto 
{
    [TextArea] public string Oracion;
}
