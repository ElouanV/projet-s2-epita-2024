using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEntity : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject[] monsterList;
    public int randomMonster;
    public int randomPosition;

    private void Start()
    {
        randomMonster = Random.Range(0, monsterList.Length);
        randomPosition = Random.Range(0, monsterList.Length);
        SpawnMonster(monsterList[randomMonster], spawnPosition[randomPosition]);
    }

    public void SpawnMonster(GameObject prefab, Transform pos)
    {
        Instantiate(prefab, pos);
    }
    
    
}
