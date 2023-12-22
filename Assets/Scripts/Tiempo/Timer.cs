using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer :MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoTiempo;

    [SerializeField] float duracionSesionJuego = 2f * 3600f;
    [SerializeField] float duracionTrabajoReal = 8f * 3600f;
    float tiempoTranscurrido = 8f * 3600f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime * (duracionTrabajoReal/duracionSesionJuego);
        int horas = Mathf.FloorToInt(tiempoTranscurrido / 3600f);
        int minutos = Mathf.FloorToInt((tiempoTranscurrido % 3600f) / 60f);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);
        //textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        textoTiempo.text = horas.ToString("00") + ":" + minutos.ToString("00"); //+ ":" + segundos.ToString("00");
    }

    public void sumarTiempo(float tiempoAdicional) 
    {
        tiempoTranscurrido += tiempoAdicional * 3600f;
    }
}
