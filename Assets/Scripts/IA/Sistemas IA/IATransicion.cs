using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IATransicion
{
    //transicion de estado a otro
    public IADecision Decision;
    public IAEstado EstadoVerdadero;
    public IAEstado EstadoFalso;
}
