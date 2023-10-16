using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonManager : MonoBehaviour
{
    public GameObject nombreTexto;
    // Start is called before the first frame update
    void Start()
    {
        nombreTexto.SetActive(false);
    }

    public void OnMouseEnter()
    {
        nombreTexto.SetActive(true);
    }

    private void OnMouseExit()
    {
        nombreTexto.SetActive(false);
    }
}
