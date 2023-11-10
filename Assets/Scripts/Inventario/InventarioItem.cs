using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoItems
{
    Armas,
    Pociones,
    Pergaminos,
    Ingredientes,
    Tesoros
}
public class InventarioItem: ScriptableObject
{
    [Header("Parametros")]
    public string ID;
    public string nombre;
    public Sprite icono;
    [TextArea] public string descripcion;


    [Header("Informacion")]
    public TipoItems tipo;
    public bool EsConsumible;
    public bool EsAcumulable;
    public int AcumulacionMax;

    [HideInInspector] public int cantidad;


    public InventarioItem CopiarItem() 
    {
        InventarioItem nuevaInstancia = Instantiate(this);
        return nuevaInstancia;
    }


    public virtual bool UsarItem() 
    {
        return true;
    }


    public virtual bool EquiparItem()
    {
        return true;
    }

    public virtual bool RemoverItem()
    {
        return true;
    }

    public virtual string DescripcionItemCrafting() 
    {
        return "";
    }

}
