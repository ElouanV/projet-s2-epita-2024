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

    //temps d'attente
    private float waitAtSpot;
    public float startWaitAtSpot;
    public int i;

    private void Start()
    {
        i = 0;
    }

    private void Update()
    {
        i %= patrolPosition.Length;
        transform.position = Vector2.MoveTowards(transform.position, patrolPosition[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPosition[i].position) < 0.5f)
        {
            if (waitAtSpot > 0) waitAtSpot -= Time.deltaTime;
            else waitAtSpot = startWaitAtSpot;

            i++;
        }
    }
}
