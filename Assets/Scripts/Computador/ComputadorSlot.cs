using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ComputadorSlot : MonoBehaviour
{
    public int Index { get; set; }
    public Image icono;

    // Start is called before the first frame update
    void Start()
    {
        icono = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
