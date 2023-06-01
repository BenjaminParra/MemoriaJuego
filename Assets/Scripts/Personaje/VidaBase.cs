using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMaxima;

    //propiedad que puede ser regresada o modificada
    public float Salud { get; protected set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Salud = saludInicial;
    }
    public void RecibirDaño (float cantidad)
    {
        if (cantidad <= 0f)
        {
            return;
        }
        else if (Salud > 0f)
        {
            Salud -= cantidad;
            ActualizarBarraVida(Salud, saludMaxima);
            if (Salud <= 0f) 
            {
                Salud = 0f;
                ActualizarBarraVida(Salud, saludMaxima);
                PersonajeDerrotado();
            }
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual, float vidaMaxima) 
    {

    }

    protected virtual void PersonajeDerrotado() 
    {

    }
}
