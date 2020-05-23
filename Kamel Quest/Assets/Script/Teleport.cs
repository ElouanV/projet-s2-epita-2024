﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// This class allow to change position of the player  when the player enter in collision with the GameObject which is carrying this script.
///</summary>



public class Teleport : MonoBehaviour
{
    public Player player;
    // Define if the teleporter is active :
    public bool is_active;
    // Define destination position :
    public float x;
    public float y; 



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& is_active)
        {
            TeleportPlayer(x,y);
        }
    }

    ///<summary>
    /// Teleport the player to the given position
    ///<param> Parameters tpx and tpy are the position to teleport the player </param>
    ///<remaks> In our game, the z axes never change, so it is automatically set to 0, but if it needed, we can change it.</remaks>
    ///</summary>
    public void TeleportPlayer(float tpx, float tpy, float tpz = 0)
    {
        Debug.Log("[TeleportPlayer] : Teleportation ...");
        Vector3 tpposition;
        tpposition.x = tpx;
        tpposition.y = tpy;
        tpposition.z = tpz;
        player.GetComponent<Transform>().position = tpposition;
        Debug.Log("[TeleportPlayer] : Teleportation done");
    }


    
}