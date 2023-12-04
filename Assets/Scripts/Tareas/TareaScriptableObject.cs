using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TareaScriptableObject : ScriptableObject
{
    public Sprite IconoTarea;
    public string NombreTarea;
    [TextArea] public string DescripcionTarea;
    public float TiempoRestante;
    public bool ActivacionTiempo;
}
