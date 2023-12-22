using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaEmergenteManager : Singleton<VentanaEmergenteManager>
{
    [SerializeField] private GameObject ventana;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuestraVentana() 
    {
        StartCoroutine(MostrarVentanaPorSegundos(5f));
    }
    IEnumerator MostrarVentanaPorSegundos(float segundos) 
    {
        ventana.SetActive(true);
        yield return new WaitForSeconds(segundos);
        ventana.SetActive(false);

    }
}
