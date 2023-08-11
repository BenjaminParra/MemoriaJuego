using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizadorApuntes : MonoBehaviour
{
    [Header("Apuntes")]
    [SerializeField] private ApuntesItemLista apuntes;

    [SerializeField] public int idApunte;

    private ApunteItem apunte;
    
    private bool publicado = false;
    // Start is called before the first frame update


    void Start()
    {
        apunte = GetApunte(idApunte);
    }

    // Update is called once per frame
    void Update()
    {
        ActualizaApunte(idApunte);
        CargaApunte(idApunte);
    }
   
    public ApunteItem GetApunte(int id) 
    {
        return apuntes.Apuntes[id];
    }

    public void ActualizaApunte(int id) 
    {
        apuntes.Apuntes[id].pistaObtenidaBool = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(apunte.pistaObtenida)).value;
        apuntes.Apuntes[id].conversadoBool = ((Ink.Runtime.BoolValue)DialogoMedianoManager.GetInstance().GetVariableState(apunte.conversado)).value;
        apuntes.Apuntes[id].pistaObtenidaString = ((Ink.Runtime.StringValue)DialogoMedianoManager.GetInstance().GetVariableState(apunte.pista)).value;
        apuntes.Apuntes[id].numeroDireccion = ((Ink.Runtime.IntValue)DialogoMedianoManager.GetInstance().GetVariableState(apunte.direccion)).value;
    }

    public void CargaApunte(int id) 
    {
        if (publicado == false && apuntes.Apuntes[id].conversadoBool && apuntes.Apuntes[id].numeroDireccion != 0)
        {
            ApuntesItemManager.Instance.CargarApunteConId(id);
            publicado = true;
        }
    }
}
