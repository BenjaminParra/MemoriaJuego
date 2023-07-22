using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private PolygonCollider2D polygonCollider2D;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider2D = GetComponentInChildren<BoxCollider2D>();
        polygonCollider2D = GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool abierta = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState("pasaste")).value;

        if (abierta) 
        {
            boxCollider2D.enabled = true;
        }

    }
}
