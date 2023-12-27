using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject nombre;
    public void OnPointerEnter(PointerEventData eventData)
    {
        nombre.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        nombre.SetActive(false);
    }
}
