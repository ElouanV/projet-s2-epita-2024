using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
    //vitesse et différentes positions possibles pour l'entité
    public float speed;
    public Transform[] patrolPosition;
    private int randomPosition;
    
    //temps d'attente
    private float waitAtSpot;
    public float startWaitAtSpot;

    private void Start()
    {
        randomPosition = Random.Range(0, patrolPosition.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPosition[randomPosition].position,
            speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPosition[randomPosition].position) < 0.5f)
        {
            if (waitAtSpot > 0)
            {
                waitAtSpot -= Time.deltaTime;
            }
            else
            {
                randomPosition = Random.Range(0, patrolPosition.Length);
                waitAtSpot = startWaitAtSpot;
            }
        }
    }
}
