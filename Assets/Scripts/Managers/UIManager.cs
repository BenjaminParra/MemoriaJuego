using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Paneles")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelTienda;
    [SerializeField] private GameObject panelCrafting;
    [SerializeField] private GameObject panelCraftingInfo;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelInspectorQuests;
    [SerializeField] private GameObject panelPersonajeQuests;

    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;
    [SerializeField] private Image expPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI nivelTMP;
    [SerializeField] private TextMeshProUGUI monedasTMP;


    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDañoTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    [SerializeField] private TextMeshProUGUI statExpTotalTMP;
    [SerializeField] private TextMeshProUGUI atributoFuerzaTMP;
    [SerializeField] private TextMeshProUGUI atributoInteligenciaTMP;
    [SerializeField] private TextMeshProUGUI atributoDestrezaTMP;
    [SerializeField] private TextMeshProUGUI atributoPuntosDisponiblesTMP;


    private float vidaActual;
    private float vidaMax;
    private float manaActual;
    private float manaMax;
    private float expActual;
    private float expRequeridaNuevoNivel;
    private int nivelActual;
    private int nivelMax;



    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
        ActualizarPanelStats();
    }

    private void ActualizarUIPersonaje() 
    {
        //Modificamos barra
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActual / vidaMax, 10f * Time.deltaTime);
        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, manaActual / manaMax, 10f * Time.deltaTime);
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, expActual / expRequeridaNuevoNivel, 10f * Time.deltaTime);
        vidaTMP.text = $"{vidaActual}/{vidaMax}";
        manaTMP.text = $"{manaActual}/{manaMax}";
        //Con esto verificamos si es el nivel maximo
        if ( nivelActual == nivelMax)
        {
            expTMP.text = $" Nivel máximo";
            nivelTMP.text = $"Nivel máximo";
        }
        else
        {
            nivelTMP.text = $"Nivel {stats.Nivel}";
            expTMP.text = $"{((expActual / expRequeridaNuevoNivel) * 100):F2}% ";
        }
        monedasTMP.text = MonedasManager.Instance.MonedasTotales.ToString();

    }

    private void ActualizarPanelStats() 
    {
        if (panelStats.activeSelf == false)
        {
            return;
        }
        if (stats.Nivel == nivelMax)
        {
            statDañoTMP.text = stats.Daño.ToString();
            statDefensaTMP.text = stats.Defensa.ToString();
            statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
            statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
            statVelocidadTMP.text = stats.Velocidad.ToString();
            statNivelTMP.text = stats.Nivel.ToString();
            statExpTMP.text = "Máx";
            statExpRequeridaTMP.text = "Máx";
            statExpTotalTMP.text = stats.ExpTotal.ToString();
            atributoFuerzaTMP.text = stats.Fuerza.ToString();
            atributoInteligenciaTMP.text = stats.Inteligencia.ToString();
            atributoDestrezaTMP.text = stats.Destreza.ToString();
            atributoPuntosDisponiblesTMP.text = $"Puntos: {stats.PuntosDisponibles}";
        }
        else
        {
            statDañoTMP.text = stats.Daño.ToString();
            statDefensaTMP.text = stats.Defensa.ToString();
            statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
            statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
            statVelocidadTMP.text = stats.Velocidad.ToString();
            statNivelTMP.text = stats.Nivel.ToString();
            statExpTMP.text = stats.ExpActual.ToString();
            statExpRequeridaTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();
            statExpTotalTMP.text = stats.ExpTotal.ToString();
            atributoFuerzaTMP.text = stats.Fuerza.ToString();
            atributoInteligenciaTMP.text = stats.Inteligencia.ToString();
            atributoDestrezaTMP.text = stats.Destreza.ToString();
            atributoPuntosDisponiblesTMP.text = $"Puntos: {stats.PuntosDisponibles}";
        }

    }
    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax) 
    {
        vidaActual= pVidaActual;
        vidaMax= pVidaMax;  
    }
    public void ActualizarManaPersonaje(float pManaActual, float pManaMax)
    {
        manaActual = pManaActual;
        manaMax = pManaMax;
    } 
    public void ActualizarExpPersonaje(float pManaActual, float pExpRequerida, int pNivelActual, int pNivelMax)
    {
        expActual = pManaActual;
        expRequeridaNuevoNivel = pExpRequerida;
        nivelActual = pNivelActual;
        nivelMax = pNivelMax;
    }

    #region Paneles
    public void AbrirCerrarPanelStats() {
        //Este metodo recibe un booleano como parametro, es por esto que se le pasa la negacion de la consulta si es que está activo o no
        panelStats.SetActive(!panelStats.activeSelf);
    }
    public void AbrirCerrarPanelInventario() {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    public void AbrirCerrarPanelInspectorQuests()
    {
        panelInspectorQuests.SetActive(!panelInspectorQuests.activeSelf);
    }

    public void AbrirCerrarPanelTienda() 
    {
        panelTienda.SetActive(!panelTienda.activeSelf);
    }

    public void AbrirCerrarPanelPersonajeQuests() 
    { 
        panelPersonajeQuests.SetActive(!panelPersonajeQuests.activeSelf);
    }

    public void AbrirPanelCrafting() 
    {
        panelCrafting.SetActive(true);
    }

    public void CerarPanelCrafting() 
    {
        panelCrafting.SetActive(false);
        AbrirCerrarPanelCraftingInformacion(false);
    }

    public void AbrirCerrarPanelCraftingInformacion(bool estado) 
    {
        panelCraftingInfo.SetActive(estado);
    }

    public void AbrirPanelInteraccion(InteraccionExtraNPC tipoInteraccion) 
    { 
        switch (tipoInteraccion)
        {
            case InteraccionExtraNPC.Quests: 
                AbrirCerrarPanelInspectorQuests();
                break;

            case InteraccionExtraNPC.Tienda:
                AbrirCerrarPanelTienda();
                break;

            case InteraccionExtraNPC.Crafting:
                AbrirPanelCrafting();
                break;

        }
    }

    public void AbrirCerrarPanelInspectorQuestConEstado(bool estado) 
    {
        panelInspectorQuests.SetActive(estado);
    }

    public bool EstaAbiertoPanelInspectorQuest() 
    {
        return panelInspectorQuests.activeSelf;
    }



    #endregion



}
