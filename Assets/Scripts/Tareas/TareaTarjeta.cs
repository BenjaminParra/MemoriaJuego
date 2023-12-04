using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TareaTarjeta : MonoBehaviour
{
    [SerializeField] private Image tareaIcono;
    [SerializeField] private TextMeshProUGUI tareaNombre;
    [SerializeField] private TextMeshProUGUI tareaDescripcion;
     
    public Tarea TareaCargada { get; set; }

    public void ConfigurarTarea(Tarea tarea) 
    {
        TareaCargada = tarea;
        tareaIcono.sprite = tarea.IconoTarea;
        tareaNombre.text = tarea.NombreTarea;
        tareaDescripcion.text = tarea.DescripcionTarea;
        tarea.ActivacionTiempo = true;
        Countdown countdown = GetComponent<Countdown>();
        countdown.inicioTemporizador = true;
        countdown.tiempoRestante = tarea.TiempoRestante;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
