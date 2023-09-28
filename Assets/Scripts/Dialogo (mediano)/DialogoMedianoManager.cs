using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using Ink.UnityIntegration;

public class DialogoMedianoManager : MonoBehaviour
{
    [Header("Condig")]
    [SerializeField] private float velocidadTexto = 0.04f;
    /*
    [Header("Archivo Globals Ink")]
    [SerializeField] private InkFile archivoGlobalsInk;*/

    [Header("Load globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [Header("Panel Dialogo Mediano")]
    [SerializeField] private GameObject dialogoMedianoPanel;
    [SerializeField] private Image npcCara;
    [SerializeField] private TextMeshProUGUI dialogoMedianoTexto;
    [SerializeField] private TextMeshProUGUI dialogoMedianoNombreTexto;
    [SerializeField] private GameObject continuarIcono;
    [SerializeField] private Animator portraitAnimator;

    
    [Header("Respuestas")]

    [SerializeField] private GameObject[] respuestas;

    private Animator layoutAnimator;
    private TextMeshProUGUI[] respuestasText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private Coroutine displayLineCoroutine;
    private bool puedeContinuarSiguienteLinea = false;
    private static DialogoMedianoManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";


    private DialogueVariables dialogueVariables;
    private void Awake()
    {
        if (instance != null) 
        {
            Debug.Log("Se encontró mas de un dialogo mediano manager en esta escena");
        }
        instance = this;


        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogoMedianoManager GetInstance() 
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogoMedianoPanel.SetActive(false);
        layoutAnimator = dialogoMedianoPanel.GetComponent<Animator>();
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
        if (puedeContinuarSiguienteLinea && Input.GetKeyDown(KeyCode.Space) && currentStory.currentChoices.Count == 0) 
        {
            ContinuarStory();
        }
    }

    public void EntrarModoDialogoMediano(TextAsset inkJSON)
    {
        UIManager.Instance.AbrirCerrarPanelBotonesCiber(false);
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogoMedianoPanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        //reset
        dialogoMedianoNombreTexto.text = "personajeDefault";
        portraitAnimator.Play("Default");
        layoutAnimator.Play("izq");
        ContinuarStory();
    }

    private IEnumerator SalirModoDialogoMediano() 
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialogoMedianoPanel.SetActive(false);
        dialogoMedianoTexto.text = "";
        UIManager.Instance.AbrirCerrarPanelBotonesCiber(true);


    }

    private void ContinuarStory() 
    {
        if (currentStory.canContinue)
        {
            //dialogoMedianoTexto.text = currentStory.Continue();
            if(displayLineCoroutine != null) 
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine( SalirModoDialogoMediano());
        }
    }
    private IEnumerator DisplayLine(string line) 
    {
        // vaciamos el string del dialogo
        dialogoMedianoTexto.text = "";
        // escondemos items mientras se escribe el texto
        continuarIcono.SetActive(false);

        EscondeRespuesta();

        puedeContinuarSiguienteLinea = false;

        // Vamos mostrando letra por letra 
        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogoMedianoTexto.text = line;
                break;

            }
            dialogoMedianoTexto.text += letter;
            yield return new WaitForSeconds(velocidadTexto);
        }

        //activamos items luego de haber escrito

        continuarIcono.SetActive(true);
        DespliegaRespuestas();
        puedeContinuarSiguienteLinea = true;
    }

    private void EscondeRespuesta() 
    {
        foreach (GameObject botonRespuesta in respuestas) 
        {
            botonRespuesta.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags) 
    {
        //recorre los tag del ink file
        foreach (string tag in currentTags) 
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2) 
            {
                Debug.LogError("Tag no pudo ser parseado: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            //manejo de los tag, es decir speaker, portrait, etc

            switch (tagKey) 
            {
                case SPEAKER_TAG:
                    //Debug.Log("speaker=" + tagValue);
                    dialogoMedianoNombreTexto.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    //Debug.Log("portrait=" + tagValue);
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    //Debug.Log("layout=" + tagValue);
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag esta entrando pero no fue bien manejado: " + tag);
                    break;
            }
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
        //StartCoroutine(SeleccionaPrimeraOpcion());
    }
    private IEnumerator SeleccionaPrimeraOpcion() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(respuestas[0].gameObject);
    }
    public void SeleccionaOpcion(int indexRespuesta) 
    {
        /*
        if (puedeContinuarSiguienteLinea)
        {
            currentStory.ChooseChoiceIndex(indexRespuesta);
        }*/
        currentStory.ChooseChoiceIndex(indexRespuesta);
        ContinuarStory();
    }

    public Ink.Runtime.Object GetVariableState(string variableName) 
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable fue encontrada nula:" + variableName);
        }
        return variableValue;
    }

    
    public void ModificarVariable(string nombreVariable) 
    {
        /*
        currentStory = new Story(loadGlobalsJSON.text);
        currentStory.variablesState[nombreVariable] = nuevoValor;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
        Debug.Log("La variable "+nombreVariable + " es: "+currentStory.variablesState[nombreVariable]);*/
        dialogueVariables.CambiaVariable(nombreVariable, loadGlobalsJSON);
    }

}
