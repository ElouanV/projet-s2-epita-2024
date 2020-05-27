using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTP : MonoBehaviour
{
    public Player player;
    public int x;
    public int y;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& player.nbrOfKey == 2) TeleportPlayer(x,y);
    }

    ///<summary>
    /// Teleport the player to the given position
    ///<param> Parameters tpx and tpy are the position to teleport the player </param>
    ///<remaks> In our game, the z axes never change, so it is automatically set to 0, but if it needed, we can change it.</remaks>
    ///</summary>
    public void TeleportPlayer(float tpx, float tpy, float tpz = 0)
    {
        Vector3 tpposition;
        tpposition.x = tpx;
        tpposition.y = tpy;
        tpposition.z = tpz;
        player.GetComponent<Transform>().position = tpposition;
    }

}
