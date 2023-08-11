using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    [SerializeField] private string nombreVariableInk;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider2D = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool abierta = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(nombreVariableInk)).value;

        if (abierta) 
        {
            boxCollider2D.enabled = true;
        }

    }
}
