using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaTrigger : MonoBehaviour
{
    [SerializeField] private PuertaAnimator puerta;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puerta.AbrirPuerta();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puerta.CerrarPuerta();
        }
    }

}
