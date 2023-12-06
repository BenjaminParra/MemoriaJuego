using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputadorTrigger : MonoBehaviour
{
    [Header("icono E")]
    [SerializeField] private GameObject npcButtonInteractuar;

    private bool jugadorEnRango;
    private bool cargadosPrederminados = false;
    private void Awake()
    {
        jugadorEnRango = false;
        npcButtonInteractuar.SetActive(false);
    }
    private void Update()
    {
        if (jugadorEnRango) 
        {
            npcButtonInteractuar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.Instance.AbrirCerraPanelComputador(true);
                if (cargadosPrederminados == false)
                {
                    ComputadorUI.Instance.CargarItemCreados();
                    cargadosPrederminados = true;
                }
                
            }
        }
        else
        {
            npcButtonInteractuar.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnRango = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnRango = false;
        }
    }
}
