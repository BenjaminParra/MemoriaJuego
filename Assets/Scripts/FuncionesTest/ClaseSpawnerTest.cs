using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClaseSpawnerTest : MonoBehaviour
{
    [SerializeField] public GameObject enemigoPrefab;

    public Vector3 minPosition;
    public Vector3 maxPosition;

    private void Start()
    {
        Test();
    }

    public void Test() 
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z));

        Instantiate(enemigoPrefab,randomPosition, Quaternion.identity);
    }
}
