using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuToggle : Singleton<MenuToggle>
{
    [SerializeField] bool estadoInicial;
    bool estadoActual;
    [SerializeField] UIAnimation uIAnimation;
    [SerializeField] UnityEvent turnedOn;
    [SerializeField] UnityEvent turnedOff;

    public UnityEvent TurnedOn => turnedOn;
    public UnityEvent TurnedOff => turnedOff;


    private void Start()
    {
        if (estadoInicial)
        {
            TurnOn();
        }
        else 
        {
            TurnOff();
        }
    }
    public void ToggleState() 
    {
        if (!uIAnimation.IsPlaying)
        {
            estadoActual = !estadoActual;
            if (estadoActual)
            {
                TurnOn();
            }
            else
            {
                TurnOff();
            }
        }

    }
    public void TurnOn() 
    {
        if (!uIAnimation.IsPlaying)
        {
            estadoActual = true;
            turnedOn.Invoke();
        }
    }

    public void TurnOff()
    {
        if (!uIAnimation.IsPlaying)
        {
            estadoActual = false;
            turnedOff.Invoke();
        }
    }
}
