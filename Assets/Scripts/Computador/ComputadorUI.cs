using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputadorUI : Singleton<ComputadorUI>
{
    [Header("Panel Computador Descripcion")]

    [SerializeField] private GameObject panelComputadorDescripcion;
    [SerializeField] private Image appIcono;
    [SerializeField] private TextMeshProUGUI appNombre;
    [SerializeField] private TextMeshProUGUI appDescripcion;

    [SerializeField] private ComputadorSlot iconoPrefab;
    [SerializeField] private Transform contenedor;


    [SerializeField] private GameObject ventanaInstalacion;
    [SerializeField] private TextMeshProUGUI textoInstalacion;

    [SerializeField] private Timer timerManager;


    public ComputadorSlot SlotSeleccionado { get; private set; }
    List<ComputadorSlot> iconosDisponibles = new List<ComputadorSlot>();

    void Start()
    {
        InicializarInventario();
    }
    private void Update()
    {
        ActualizarSlotSeleccionado();
    }

    private void InicializarInventario() 
    {
        for (int i = 0; i < Computador.Instance.NumeroDeSlots; i++)
        {
            ComputadorSlot nuevoIcono = Instantiate(iconoPrefab, contenedor);
            nuevoIcono.Index = i;
            //nuevoIcono.icono.sprite = Computador.Instance.ItemsComputador[i].Icono;
            iconosDisponibles.Add(nuevoIcono);
            //if (Computador.Instance.ItemsComputador[i] != null /*&& Computador.Instance.ItemsComputador[i].Visible*/)
            //{

            //}


        }
    }

    public void CargarItemCreados() 
    {
        for(int i = 0;i < Computador.Instance.AppsDeterminadas.Length;i++) 
        {
            Computador.Instance.AņadirItemEnSlotDisponible(Computador.Instance.AppsDeterminadas[i]);
        }
    }

    private void ActualizarComputadorDescripcion(int index) 
    {
        if (Computador.Instance.ItemsComputador[index] != null)
        {
            appIcono.sprite = Computador.Instance.ItemsComputador[index].Icono;
            appNombre.text = Computador.Instance.ItemsComputador[index].Nombre;
            appDescripcion.text = Computador.Instance.ItemsComputador[index].Descripcion;
            panelComputadorDescripcion.SetActive(true);
        }
        else 
        {
            panelComputadorDescripcion.SetActive(false);
        }
    }
    private void ActualizarSlotSeleccionado()
    {
        GameObject goSeleccionado = EventSystem.current.currentSelectedGameObject;
        if (goSeleccionado == null)
        {
            return;
        }
        ComputadorSlot slot = goSeleccionado.GetComponent<ComputadorSlot>();
        if (slot != null)
        {
            SlotSeleccionado = slot;
        }
    }

    public void DibujarItemEnInventario(ComputadorItem itemPorAņadir, int itemIndex) 
    {
        ComputadorSlot slot = iconosDisponibles[itemIndex];
        if (itemPorAņadir != null) 
        {
            //slot.icono.enabled = true;
            slot.ActivarSlot(true);
            slot.ActualizaSlot(itemPorAņadir);
        }
        else
        {
            slot.ActivarSlot(false);
        }
    }

    public void AbrirApp() 
    {
        if (Computador.Instance.ItemsComputador[SlotSeleccionado.Index].EsTecnologia && !Computador.Instance.ItemsComputador[SlotSeleccionado.Index].Publicado)
        {

            UIManager.Instance.AbrirCerrarPanelConfirmacionInstalacion();

        }else if (SlotSeleccionado != null && !Computador.Instance.ItemsComputador[SlotSeleccionado.Index].EsTecnologia)
        {
            SlotSeleccionado.AbrirSlot();

        }else if (Computador.Instance.ItemsComputador[SlotSeleccionado.Index].EsTecnologia && Computador.Instance.ItemsComputador[SlotSeleccionado.Index].Publicado)
        {
            SlotSeleccionado.AbrirSlot();
        }
    }

    public void InstalarAplicacion() 
    {
        UIManager.Instance.AbrirCerrarPanelConfirmacionInstalacion();
        StartCoroutine(MostrarVentanaPorSegundos(5f, Computador.Instance.ItemsComputador[SlotSeleccionado.Index].TiempoInstalacion.ToString()));
        timerManager.sumarTiempo(Computador.Instance.ItemsComputador[SlotSeleccionado.Index].TiempoInstalacion);
        Computador.Instance.ItemsComputador[SlotSeleccionado.Index].Publicado = true;

    }


    IEnumerator MostrarVentanaPorSegundos(float segundos, string hora)
{
    ventanaInstalacion.SetActive(true);
        textoInstalacion.text = $"El tiempo necesario para instalaciķn y aprendizaje es de {hora} hrs";
    yield return new WaitForSeconds(segundos);
    ventanaInstalacion.SetActive(false);
    SlotSeleccionado.AbrirSlot();

}


#region Evento
private void SlotInteraccionRespuestaApp(TipoDeInteraccionSlot tipo, int index)
    {
        if (tipo == TipoDeInteraccionSlot.Click)
        {
            ActualizarComputadorDescripcion(index);
        }
    }

    private void OnEnable()
    {
        ComputadorSlot.EventoSlotInteraccionApp += SlotInteraccionRespuestaApp;
    }


    private void OnDisable()
    {
        ComputadorSlot.EventoSlotInteraccionApp -= SlotInteraccionRespuestaApp;
    }
    #endregion

    

    

}

