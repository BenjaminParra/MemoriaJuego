using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMaximo;
    [SerializeField] private float regeneracionPorSegundo;

    public float ManaActual { get; private set; }

    public bool SePuedeRestaurar => ManaActual < manaMaximo;

    private PersonajeVida personajeVida;

    private void Awake()
    {
        personajeVida = GetComponent<PersonajeVida>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();
        InvokeRepeating(nameof(RegenerarMana), 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UsarMana(10f);
        }
    }

    public void UsarMana(float cantidad)
    {
        if (ManaActual >= cantidad)
        {
            ManaActual -= cantidad;
            ActualizarBarraMana();
        }
    }

    public void RestaurarMana(float cantidad) 
    {
        if (ManaActual >= manaMaximo)
        {
            return;
        }

        ManaActual += cantidad;

        if (ManaActual > manaMaximo)
        {
            ManaActual= manaMaximo;
        }

        UIManager.Instance.ActualizarManaPersonaje(ManaActual, manaMaximo);
    }

    private void RegenerarMana() 
    {
        if (personajeVida.Salud > 0 && ManaActual < manaMaximo)
        {
            ManaActual += regeneracionPorSegundo;
            ActualizarBarraMana();
        }
    }

    public void RestablecerMana() 
    {
        ManaActual= manaInicial;
        ActualizarBarraMana();
    }

    private void ActualizarBarraMana() 
    {
        UIManager.Instance.ActualizarManaPersonaje(ManaActual,manaMaximo);
    }
}
