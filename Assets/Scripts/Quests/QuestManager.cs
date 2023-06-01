using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Personaje")]
    [SerializeField] private Personaje personaje;

    [Header("Quests")]
    [SerializeField] private Quest[] questDisponibles;

    [Header("InspectorQuest")]
    [SerializeField] private InspectorQuestDescripcion inspectorQuestPrefab;
    [SerializeField] private Transform inspectorQuestContenedor;

    [Header("PersonajeQuest")]
    [SerializeField] private PersonajeQuestDescripcion personajeQuestPrefab;
    [SerializeField] private Transform personajeQuestContenedor;

    [Header("PanelQuestCompletado")]
    [SerializeField] private GameObject panelQuestCompletado;
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questRecompensaOro;
    [SerializeField] private TextMeshProUGUI questRecompensaExp;

    [SerializeField] private TextMeshProUGUI questRecompensaItem;
    [SerializeField] private Image questRecompensaItemIcono;


    public Quest QuestPorReclamar { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        CargarQuestEnInspector();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            A�adirProgreso("Mata10",1);
            A�adirProgreso("Mata25", 1);
            A�adirProgreso("Mata50", 1);
        }
    }


    private void CargarQuestEnInspector() 
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            InspectorQuestDescripcion nuevoQuest = Instantiate(inspectorQuestPrefab, inspectorQuestContenedor);
            nuevoQuest.ConfigurarQuestUI(questDisponibles[i]);

        }  
    }

    private void A�adirQuestPorCompletar(Quest questPorCompletar) 
    {
        PersonajeQuestDescripcion nuevoQuest = Instantiate(personajeQuestPrefab, personajeQuestContenedor);
        nuevoQuest.ConfigurarQuestUI(questPorCompletar);
    }

    public void A�adirQuest(Quest questPorCompletar) 
    {
        A�adirQuestPorCompletar(questPorCompletar);
    }
    public void ReclamarRecompensa() 
    {
        if (QuestPorReclamar == null)
        {
            return;
        }

        MonedasManager.Instance.A�adirMonedas(QuestPorReclamar.RecompensaOro);
        personaje.PersonajeExperiencia.A�adirExperiencia(QuestPorReclamar.RecompensaExp);
        Inventario.Instance.A�adirItems(QuestPorReclamar.RecompensaItem.Item, QuestPorReclamar.RecompensaItem.Cantidad);
        panelQuestCompletado.SetActive(false);
        QuestPorReclamar = null;
    }

    public void A�adirProgreso(string questID, int cantidad) 
    {
        Quest questPorActualizar = QuestExiste(questID);
        if (questPorActualizar.QuestAceptado) 
        {
            questPorActualizar.A�adirProgreso(cantidad);
        }
        
    }

    private Quest QuestExiste(string questID) 
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            if (questDisponibles[i].ID == questID)
            {
                return questDisponibles[i];
            }
        }
        return null;
    }

    private void MostrarQuestCompletado(Quest questCompletado) 
    {
        panelQuestCompletado.SetActive(true);

        questNombre.text = questCompletado.Nombre;
        questRecompensaOro.text = questCompletado.RecompensaOro.ToString();
        questRecompensaExp.text = questCompletado.RecompensaExp.ToString();
        questRecompensaItem.text = questCompletado.RecompensaItem.Cantidad.ToString();
        questRecompensaItemIcono.sprite = questCompletado.RecompensaItem.Item.icono;
    }
    private void QuestCompletadoRespuesta(Quest questCompletado)
    {
        QuestPorReclamar = QuestExiste(questCompletado.ID);
        if (QuestPorReclamar != null)
        {
            MostrarQuestCompletado(QuestPorReclamar);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            questDisponibles[i].ResetQuest();
        }
        Quest.EventoQuestCompletado += QuestCompletadoRespuesta;
    }


    private void OnDisable()
    {
        Quest.EventoQuestCompletado -= QuestCompletadoRespuesta;
    }
}
