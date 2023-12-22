using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AmenazaManager : MonoBehaviour
{
    public bool amenazaFueElegida;
    [SerializeField] private Amenaza[] amenazas;
    [SerializeField] private SliderController sliderEmpresa;
    [SerializeField] public float tiempoTranscurrido;

    public bool salioPar;
    public float cuantoDemora;

    Amenaza amenazaElegida;
    // Start is called before the first frame update
    void Start()
    {
        amenazaElegida = amenazas[0];
        amenazaFueElegida = true;
        LimpiarAmenaza();
        salioPar = false;
        MedirTiempoLanzamiento();
        
    }

    // Update is called once per frame
    void Update()
    {
        cuantoDemora += Time.deltaTime;
        tiempoTranscurrido -= Time.deltaTime;
       // FuncionAzar();
    }

    private void EjecutarAtaques() 
    {
        if (tiempoTranscurrido < 0 || amenazaFueElegida != true)
        {
            return;
        }
        else 
        {
            if (tiempoTranscurrido < amenazaElegida.AmenazaMadre.tiempoPrimerAtaque && !amenazaElegida.AmenazaMadre.primerAtaqueRealizado)
            {
                sliderEmpresa.DisminuyeProgreso(amenazaElegida.AmenazaMadre.porcentajePrimerAtaque);
                amenazaElegida.AmenazaMadre.primerAtaqueRealizado = true;
            }
            if (tiempoTranscurrido < amenazaElegida.AmenazaMadre.tiempoSegundoAtaque && !amenazaElegida.AmenazaMadre.segundoAtaqueRealizado)
            {
                sliderEmpresa.DisminuyeProgreso(amenazaElegida.AmenazaMadre.porcentajeSegundoAtaque);
                amenazaElegida.AmenazaMadre.segundoAtaqueRealizado = true;
            }
            if (tiempoTranscurrido < amenazaElegida.AmenazaMadre.tiempoTercerAtaque && !amenazaElegida.AmenazaMadre.tercerAtaqueRealizado)
            {
                sliderEmpresa.DisminuyeProgreso(amenazaElegida.AmenazaMadre.porcentajeTercerAtaque);
                amenazaElegida.AmenazaMadre.tercerAtaqueRealizado = true;
            }
        }
    }

    private void LimpiarAmenaza() 
    {
        amenazaElegida.AmenazaMadre.primerAtaqueRealizado = false;
        amenazaElegida.AmenazaMadre.segundoAtaqueRealizado = false;
        amenazaElegida.AmenazaMadre.tercerAtaqueRealizado=false;
    }
    void MedirTiempoLanzamiento()
    {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        int resultadoDado1;
        int resultadoDado2;

        do
        {
            resultadoDado1 = UnityEngine.Random.Range(1, 7);
            resultadoDado2 = UnityEngine.Random.Range(1, 7);

        } while (resultadoDado1 != resultadoDado2);

        stopwatch.Stop();

        // Imprimir el tiempo transcurrido en milisegundos
        Debug.Log("Tiempo transcurrido: " + stopwatch.ElapsedMilliseconds + " ms");

        Debug.Log("¡Obtuviste dos números iguales! Objeto activado.");
    }
    private void FuncionAzar() 
    {
        int resultado1;
        int resultado2;

        if (!salioPar)
        {
            resultado1 = Random.Range(1, 7);
            resultado2 = Random.Range(1, 7);
            if (resultado1 == resultado2)
            {
                Debug.Log("Obtuviste 2 numero iguales");
                salioPar = true;
                cuantoDemora += 1000;
            }
            else
            {
                resultado1 = Random.Range(1, 7);
                resultado2 = Random.Range(1, 7);
            }

            
        }
    }
}
