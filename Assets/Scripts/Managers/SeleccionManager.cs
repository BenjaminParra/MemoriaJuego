using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionManager : MonoBehaviour
{
    public static Action<EnemigoInteraccion> EventoEnemigoSeleccionado;
    public static Action EventoObjetoNoSeleccionado;

    public EnemigoInteraccion EnemigoSeleccionado { get; set; }

    private Camera camara;


    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SeleccionarEnemigo();
    }

    private void SeleccionarEnemigo() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(camara.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,LayerMask.GetMask("Enemigo"));
            if (hit.collider != null)
            {
                if (EnemigoSeleccionado != null) 
                {
                    EventoObjetoNoSeleccionado?.Invoke();
                }
                EnemigoSeleccionado = hit.collider.GetComponent<EnemigoInteraccion>();
                //agregue esto para eliminar el circulo
                if (EnemigoSeleccionado.GetComponent<EnemigoVida>().Salud > 0f)
                {
                    EventoEnemigoSeleccionado?.Invoke(EnemigoSeleccionado);
                }
                else 
                {
                    //como singleton se puede llamar de esta manera
                    EnemigoLoot enemigoLoot = EnemigoSeleccionado.GetComponent<EnemigoLoot>();
                    LootManager.Instance.MostrarLoot(enemigoLoot);
                }
                
            }
            else
            {
                EventoObjetoNoSeleccionado?.Invoke();
            }
        }
    }
}
