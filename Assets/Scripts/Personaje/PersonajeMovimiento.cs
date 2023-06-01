using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    //para definirla en el inspector
    [SerializeField] private float velocidad;

    public bool EnMovimiento => direccionMovimiento.magnitude > 0f;
    public Vector2 DireccionMovimiento => direccionMovimiento;
    //para acceder desde otra clase se ocupa esto que lo llaman propiedad
    //public float Velocidad => velocidad;
    private new Rigidbody2D rigidbody2D; // OJO que agregue un new!!!
    private Vector2 input;
    private Vector2 direccionMovimiento;
    private PersonajeVida personajeVida;

    private void Awake()
    {
        //Se inicializa el componente 
        rigidbody2D = GetComponent<Rigidbody2D>();
        personajeVida = GetComponent<PersonajeVida>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (personajeVida.Derrotado) 
        {
            direccionMovimiento = Vector2.zero;
            return;
        }

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
   
        //componente X
        if (input.x > 0.1f)
        {
            direccionMovimiento.x = 1f;
        }
        else if (input.x <0f)
        {
            direccionMovimiento.x = -1f;
        }
        else
        {
            direccionMovimiento.x = 0f;
        }

        //componente Y
        if (input.y > 0.1f)
        {
            direccionMovimiento.y = 1f;
        }
        else if (input.y < 0f)
        {
            direccionMovimiento.y = -1f;
        }
        else
        {
            direccionMovimiento.y = 0f;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }
}
