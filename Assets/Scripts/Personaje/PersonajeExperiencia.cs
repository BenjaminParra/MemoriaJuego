
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Config")]
    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    private float expActual;
    private float expRequeridaSiguienteNivel;
    // Start is called before the first frame update
    void Start()
    {
        stats.Nivel = 1;
        expRequeridaSiguienteNivel = expBase;
        stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
        ActualizarBarraExp();
    }

    
    
    public void AñadirExperiencia(float expObtenida)
    {

        if (expObtenida <= 0)
        {
            return;
        }
        if (stats.Nivel < nivelMax)
        {
            expActual += expObtenida;
            stats.ExpActual = expActual;

            if (expActual == expRequeridaSiguienteNivel)
            {
                stats.ExpTotal += expObtenida;
                ActualizarNivel();
            }
            else if (expActual > expRequeridaSiguienteNivel)
            {
                float dif = expActual - expRequeridaSiguienteNivel;
                stats.ExpTotal += dif;
                ActualizarNivel();
                AñadirExperiencia(dif);
            }

            ActualizarBarraExp();



        }
        else 
        {
            stats.ExpTotal += expObtenida;
        }

    }

    /*
    if (expObtenida <= 0) { return; }

    float expRestanteNuevoNivel = expRequeridaSiguienteNivel - expActualTemp;
    if (expObtenida >= expRestanteNuevoNivel)
    {
        if (stats.Nivel < nivelMax)
        {
            expObtenida -= expRestanteNuevoNivel;
            expActual += expObtenida;
            ActualizarNivel();
            AñadirExperiencia(expObtenida);

        }
        else
        {
            expActual = expRequeridaSiguienteNivel;
            expActualTemp = expRequeridaSiguienteNivel;

        }

    }
    else
    {
        expActual += expObtenida;
        expActualTemp += expObtenida;
        if (expActualTemp == expRequeridaSiguienteNivel)
        {
            ActualizarNivel();

        }
    }
    //stats.ExpActual = expActual;


    stats.ExpTotal += expObtenida;

    ActualizarBarraExp();


    /*
    if (expObtenida <= 0) return;
    expActual += expObtenida;
    stats.ExpActual = expActual;

    if (expActual == expRequeridaSiguienteNivel)
    {
        ActualizarNivel();
    }
    else if (expActual > expRequeridaSiguienteNivel)
    {
        if (stats.Nivel < nivelMax)
        {
            float dif = expActual - expRequeridaSiguienteNivel;
            ActualizarNivel();
            AñadirExperiencia(dif);
        }
        else if (stats.Nivel >= nivelMax)
        {
            expActual = expRequeridaSiguienteNivel;
            expActualTemp = expRequeridaSiguienteNivel;
        }

    }

    stats.ExpTotal += expObtenida;
    ActualizarBarraExp();*/





    private void ActualizarNivel()
    {
        if (stats.Nivel < nivelMax)
        {
            stats.Nivel++;
            stats.ExpActual = 0;
            expActual = 0;
            expRequeridaSiguienteNivel *= valorIncremental;
            stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
            stats.PuntosDisponibles += 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stats.ExpActual == 0 && stats.ExpActual == 0 && stats.Nivel == 1)
        {
            expActual = 0f;
            expRequeridaSiguienteNivel = expBase;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AñadirExperiencia(10f);
            
        }
        ActualizarBarraExp();
    }

    private void ActualizarBarraExp() 
    {
        UIManager.Instance.ActualizarExpPersonaje(expActual,expRequeridaSiguienteNivel, stats.Nivel, nivelMax);
        //UIManager.Instance.ActualizarExpPersonaje(nivelMax);

    }
    private void RespuestaEnemigoDerrotado(float exp)
    {
        AñadirExperiencia(exp);
    }

    private void OnEnable()
    {
        //de esta forma respondemos el evento que se "invoca" cuando el enemigo muere
        //RespuestaEnemigoDerrotado es la funcion que se llama cuando el enemigo muere
        //ahi daremos la experencia
        EnemigoVida.EventoEnemigoDerrotado += RespuestaEnemigoDerrotado;
    }


    private void OnDisable()
    {
        EnemigoVida.EventoEnemigoDerrotado -= RespuestaEnemigoDerrotado;
    }
}
