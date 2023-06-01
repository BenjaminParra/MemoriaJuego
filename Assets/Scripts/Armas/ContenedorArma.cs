using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContenedorArma : Singleton<ContenedorArma>
{
    [SerializeField] private Image armaIcono;
    [SerializeField] private Image armaSkillIcono;

    public ItemArma ArmaEquipada { get; set; }

    public void EquiparArma(ItemArma itemArma) 
    {
        ArmaEquipada = itemArma;
        armaIcono.sprite = itemArma.arma.ArmaIcono;
        armaIcono.gameObject.SetActive(true);
        if (itemArma.arma.Tipo == TipoArma.Magia) 
        {
            armaSkillIcono.sprite = itemArma.arma.IconoSkill;
            armaSkillIcono.gameObject.SetActive(true);
        }
        Inventario.Instance.Personaje.PersonajeAtaque.EquiparArma(itemArma);
    }

    public void RemoverArma() 
    {
        ArmaEquipada = null;
        armaIcono.gameObject.SetActive(false);
        armaSkillIcono.gameObject.SetActive(false);
        Inventario.Instance.Personaje.PersonajeAtaque.RemoverArma();
    }
}
