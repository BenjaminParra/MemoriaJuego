using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DireccionMovimiento
{
    Horizontal,
    Vertical
}
public class WaypointMovimiento : MonoBehaviour
{
    
    [SerializeField] private float velocidad;

    private bool jugadorEnRango;
    public Vector3 PuntoPorMoverse => waypoint.ObtenerPosicionMovimiento(puntoActualIndex);
    private readonly int jugadorRango = Animator.StringToHash("JugadorEnRango");
    protected Waypoint waypoint;

    protected Animator animator;
    protected int puntoActualIndex;
    protected Vector3 ultimaPosicion;

    private void Start()
    {
        waypoint = GetComponent<Waypoint>();
        animator = GetComponent<Animator>();
        puntoActualIndex = 0;
        jugadorEnRango = false;
        
    }

    private void Update()
    {
        if (jugadorEnRango ) 
        {
            
            return;

        }

        MoverPersonaje();
        RotarPersonaje();
        RotarVertical();
        if (ComprobarPuntoActualAlcanzado())
        {
            ActualizarIndexMovimiento();
        }

    }
    private void MoverPersonaje() 
    {
        transform.position = Vector3.MoveTowards(transform.position, PuntoPorMoverse, velocidad*Time.deltaTime);
    }

    private bool ComprobarPuntoActualAlcanzado()
    { 
        float distanciaHaciaPuntoActual = (transform.position - PuntoPorMoverse).magnitude;
        if (distanciaHaciaPuntoActual < 0.1f)
        {
            ultimaPosicion = transform.position;
            return true;
        }
        return false;

    }
    private void ActualizarIndexMovimiento()
    {
        if (puntoActualIndex == waypoint.Puntos.Length - 1)
        {
            puntoActualIndex = 0;
        }
        else
        {
            if (puntoActualIndex < waypoint.Puntos.Length - 1)
            {
                puntoActualIndex++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnRango = true;
            animator.SetBool(jugadorRango, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnRango = false;
            animator.SetBool(jugadorRango, false);
        }
    }



    protected virtual void  RotarPersonaje() 
    {
        
    }

    protected virtual void RotarVertical()
    {

    }
}
