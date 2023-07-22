using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAnimator : MonoBehaviour
{
    private Animator animator;
    private PolygonCollider2D polygonCollider2D;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    public void AbrirPuerta() 
    {
        animator.SetBool("Abierta" , true);
        polygonCollider2D.enabled = false;
    }

    public void CerrarPuerta() 
    {
        animator.SetBool("Abierta", false);
        
        
        polygonCollider2D.enabled = true;
    }
}
