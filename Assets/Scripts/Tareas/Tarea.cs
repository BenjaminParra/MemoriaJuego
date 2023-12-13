using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Tarea 
{
    public Sprite IconoTarea;
    public string NombreTarea;
    [TextArea] public string DescripcionTarea;
    public float DuracionMinutos;
    public bool ActivacionTiempo;
}
