using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// This class allow to change position of the camera  when the player enter in collision with the GameObject which is carrying this script.
///</summary>

public class CameraManager : MonoBehaviour
{
    public Player player;
    public bool is_active;
    public float y;
    public float z;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& is_active)
        {
            ChangeCamerPosition(y,z);
        }
    }

    ///<summary>
    /// Change the poistionn of the camera and allow to zoom on the player if needed.
    ///<remaks> In our game, the x axes of our camera never change and is always 0, but if needed, we can change it.</remaks>
    ///</summary>
    public void ChangeCamerPosition(float camy, float camz, float camx = 0)
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        Vector3 cameraposition;
        cameraposition.x = camx;
        cameraposition.y = camy;
        cameraposition.z = camz;
        camera.transform.position = cameraposition;
    }
}
