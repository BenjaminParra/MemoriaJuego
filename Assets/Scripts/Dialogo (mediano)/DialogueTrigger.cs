using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("icono E")]
    [SerializeField] private GameObject npcButtonInteractuar;


    [Header("ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool jugadorEnRango;

    private void Awake()
    {
        jugadorEnRango = false;
        npcButtonInteractuar.SetActive(false);
    }
    private void Update()
    {
        if (jugadorEnRango && !DialogoMedianoManager.GetInstance().dialogueIsPlaying)
        {
            npcButtonInteractuar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                DialogoMedianoManager.GetInstance().EntrarModoDialogoMediano(inkJSON);

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
