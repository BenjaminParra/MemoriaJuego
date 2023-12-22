using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public TextMeshProUGUI valorTexto;

    float progreso;

    private void Start()
    {
        progreso = slider.value;
        OnSliderChanged(progreso);
    }
    public Slider slider;
    public void OnSliderChanged(float valor) 
    {
        valorTexto.text = valor.ToString();
    }

    public void DisminuyeProgreso(float porcentaje) 
    {
        progreso -= porcentaje;
        slider.value = progreso;
    }
}
