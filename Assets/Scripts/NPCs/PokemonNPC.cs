using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonNPC : MonoBehaviour
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
        string nombrePokemon = ((Ink.Runtime.StringValue)DialogoMedianoManager.GetInstance().GetVariableState("pokemon_name")).value;


        if (nombrePokemon == "Charmander") 
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            polygonCollider2D.enabled = false;
            
        }
    }
}
