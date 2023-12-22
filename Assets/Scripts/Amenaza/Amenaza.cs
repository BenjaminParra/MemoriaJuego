using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amenaza : MonoBehaviour
{
    [Header("Configuracion Amenaza")]
    [SerializeField] private AmenazaMadre amenazaMadre;
    [SerializeField] private GameObject npcAsociadoOriginal;
    [SerializeField] private GameObject npcAsociadoAlterado;
    [SerializeField] private string variableInkNPCAsociado;

    public AmenazaMadre AmenazaMadre => amenazaMadre;
    public GameObject NpcAsociadoOriginal => npcAsociadoOriginal;
    public GameObject NpcAsociadoAlterado => npcAsociadoAlterado;

    public string VariableInkNPCAsociado => variableInkNPCAsociado;
}
