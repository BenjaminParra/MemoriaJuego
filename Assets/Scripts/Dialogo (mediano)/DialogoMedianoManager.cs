using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogoMedianoManager : MonoBehaviour
{
    [Header("Panel Dialogo Mediano")]
    [SerializeField] private GameObject dialogoMedianoPanel;
    [SerializeField] private Image npcCara;
    [SerializeField] private TextMeshProUGUI dialogoMedianoTexto;
    [SerializeField] private TextMeshProUGUI dialogoMedianoNombreTexto;

    [Header("Respuestas")]

    [SerializeField] private GameObject[] respuestas;

    private TextMeshProUGUI[] respuestasText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private static DialogoMedianoManager instance;
    private void Awake()
    {
        if (instance != null) 
        {
            Debug.Log("Se encontró mas de un dialogo mediano manager en esta escena");
        }
        instance = this;
    }

    public static DialogoMedianoManager GetInstance() 
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogoMedianoPanel.SetActive(false);
        respuestasText = new TextMeshProUGUI[respuestas.Length];
        int index = 0;
        foreach (GameObject respuesta in respuestas) 
        {
            respuestasText[index] = respuesta.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying) 
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ContinuarStory();
        }
    }

    public void EntrarModoDialogoMediano(TextAsset inkJSON, string nombre, Sprite npcRetrato)
    {
        currentStory = new Story(inkJSON.text);
        dialogoMedianoNombreTexto.text = nombre;
        dialogueIsPlaying = true;
        npcCara.sprite = npcRetrato;
        dialogoMedianoPanel.SetActive(true);
        ContinuarStory();
    }

    private IEnumerator SalirModoDialogoMediano() 
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialogoMedianoPanel.SetActive(false);
        dialogoMedianoTexto.text = "";
    }

    private void ContinuarStory() 
    {
        if (currentStory.canContinue)
        {
            dialogoMedianoTexto.text = currentStory.Continue();
            DespliegaRespuestas();
        }
        else
        {
            StartCoroutine( SalirModoDialogoMediano());
        }
    }
    private void DespliegaRespuestas() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > respuestas.Length) 
        {
            Debug.Log("Existen mas respuestas dadas que la UI puede soportar");
        }
        int index = 0;
        foreach (Choice choice in currentChoices) 
        {
            respuestas[index].gameObject.SetActive(true);
            respuestasText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < respuestas.Length; i++) 
        {
            respuestas[i].gameObject.SetActive(false);
        }
    }
    private IEnumerator SeleccionaPrimeraOpcion() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(respuestas[0].gameObject);
    }
    public void SeleccionaOpcion(int indexRespuesta) 
    {
        currentStory.ChooseChoiceIndex(indexRespuesta);
    }
}
