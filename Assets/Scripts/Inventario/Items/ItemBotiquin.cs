using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Botiquin")]
public class ItemBotiquin : InventarioItem
{
    [Header("Botiquin Info")]
    public float HPRestauracion;

    public override bool UsarItem()
    {
        if (Inventario.Instance.Personaje.PersonajeVida.PuedeSerCurado)
        {
            Inventario.Instance.Personaje.PersonajeVida.RestaurarSalud(HPRestauracion);
            return true;
        }
        return false;
    }

    public override string DescripcionItemCrafting()
    {
        string descripcion = "Restaura toda la salud del personaje";
        return descripcion;
    }
}
