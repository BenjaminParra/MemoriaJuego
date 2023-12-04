using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum EstadosJuego
{
    Juego,
    Pausa
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Personaje personaje;
    [SerializeField] private Transform puntoReaparicion;

    [SerializeField] private GameObject panelPausa;

    [Header("Botones")]
    [SerializeField] private Button buttonCerrar;
    public static EstadosJuego estado;

    private bool escPulsada;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        escPulsada = false;
        estado = EstadosJuego.Juego;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (personaje.PersonajeVida.Derrotado)
            {
                personaje.transform.localPosition = puntoReaparicion.position;
                personaje.RestaurarPersonaje();
            }
        }
        if (estado == EstadosJuego.Juego) 
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escPulsada)
            {
                panelPausa.SetActive(true);
                Time.timeScale = 0;
                estado = EstadosJuego.Pausa;
                escPulsada = true;
            }
        }
        
        if (!Input.GetKeyDown(KeyCode.Escape)) 
        {
            escPulsada = false;
        }
        RenaudarConTecla();
    }

    public void Renaudar() 
    {
        if (estado == EstadosJuego.Pausa)
        {
            if (!escPulsada)
            {
                panelPausa.SetActive(false);
                Time.timeScale = 1;
                estado = EstadosJuego.Juego;
                escPulsada = false;
                

            }
        }
    }
    public void RenaudarConTecla() 
    {
        if (estado == EstadosJuego.Pausa)
        {
            if (!escPulsada)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    panelPausa.SetActive(false);
                    Time.timeScale = 1;
                    estado = EstadosJuego.Juego;
                    escPulsada = false;
                }

            }
        }
    }

    public void VolverMenuPrincipal() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
        estado = EstadosJuego.Juego;
        escPulsada = false;
    }

    public void Cerrar() 
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
