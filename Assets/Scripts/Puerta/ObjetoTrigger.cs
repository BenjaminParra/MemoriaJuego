using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoObjeto
{
    Sprite,
    Collider,
    Ambos
}
public class ObjetoTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    [SerializeField] private string nombreVariableInk;
    [SerializeField] private TipoObjeto tipoObjeto;
    // Start is called before the first frame update
    void Start()
    {
        ActivaTipo(tipoObjeto);
    }

    // Update is called once per frame
    void Update()
    {
        bool abierta = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(nombreVariableInk)).value;
        if (abierta)
        {
            AccionTipoObjeto(tipoObjeto);
        }
    }

    public void ActivaTipo(TipoObjeto tipo) 
    {
        switch (tipo)
        {
            case TipoObjeto.Collider:
                boxCollider2D = GetComponent<BoxCollider2D>();
                break;
            case TipoObjeto.Sprite:
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                break;
            case TipoObjeto.Ambos:
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                boxCollider2D = GetComponent<BoxCollider2D>();
                break;
        }
    }

    public void AccionTipoObjeto(TipoObjeto tipo) 
    {
        switch (tipo)
        {
            case TipoObjeto.Collider:
                boxCollider2D.enabled = true;
                break;
            case TipoObjeto.Sprite:
                spriteRenderer.enabled = true;
                break;
            case TipoObjeto.Ambos:
                boxCollider2D.enabled = true;
                spriteRenderer.enabled = true;
                break;
        }
    }
}
