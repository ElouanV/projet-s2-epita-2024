using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePnj : MonoBehaviour
{
    //vitesse et différentes positions possibles pour l'entité
    private float speed;

    public bool finish;

    public GameObject playerObject;


    private void Update()
    {
        Movement();
    }


    public void Movement()
    {
        Player player = playerObject.GetComponent<Player>();

        speed = 5;
        player.GetComponent<PlayerControler>().moveSpeed = 0f;

        float posX = transform.position.x + 10;
        float posY = transform.position.y;

        while (!finish)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(posX, posY), 
                        speed * Time.deltaTime);

            if (transform.position.x == posX || transform.position.y == posY)
            {
                finish = true;
            }
        }
        
        Destroy(this);
    }
}
