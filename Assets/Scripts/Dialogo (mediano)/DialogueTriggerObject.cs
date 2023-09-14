using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : MonoBehaviour
{
    [Header("ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    public void AbrirDialogoMediano() 
    {
        DialogoMedianoManager.GetInstance().EntrarModoDialogoMediano(inkJSON);
    }
}
