using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : MonoBehaviour
{
    [Header("ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Panel CMD")]
    [SerializeField] private GameObject panelCmd;


    public void AbrirDialogoMediano() 
    {
        panelCmd.SetActive(false);
        DialogoMedianoManager.GetInstance().EntrarModoDialogoMediano(inkJSON);
    }
}
