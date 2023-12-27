using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : Singleton<UIAnimation> 
{
    [SerializeField] float duracion;
    [SerializeField] float espera;

    [SerializeField] AnimationCurve animationCurve;

    [SerializeField] RectTransform target;

    [SerializeField] Vector2 puntoInicial;
    [SerializeField] Vector2 puntoFinal;


    Coroutine animacionActual;

    public bool IsPlaying => animacionActual != null;
    public void FadeIn() 
    {
        if (animacionActual == null) 
        {
            animacionActual = StartCoroutine(FadeInCoroutine(puntoInicial, puntoFinal));
        }
        
    }
    public void FadeOut()
    {
        if (animacionActual == null)
        {
            animacionActual = StartCoroutine(FadeInCoroutine(puntoFinal, puntoInicial));
        }
    }
    IEnumerator FadeInCoroutine(Vector2 a, Vector2 b) 
    {
        Vector2 puntoInicial = a ;
        Vector2 puntoFinal = b ;
        float elapsed = 0;
        while (elapsed <= espera) 
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0;
        while (elapsed <= duracion) 
        {
            float porcentaje = elapsed / duracion;
            float curvaPorcentaje = animationCurve.Evaluate(porcentaje);
            elapsed += Time.deltaTime;
            Vector2 posicionActual =  Vector2.LerpUnclamped(puntoInicial, puntoFinal, curvaPorcentaje);
            target.anchoredPosition = posicionActual;
            yield return null;
        }
        target.anchoredPosition = puntoFinal;
        animacionActual = null;
    }
}
