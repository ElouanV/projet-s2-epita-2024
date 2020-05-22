using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// This class allow to change the playing music when the player enter in collision with the GameObject which is carrying this script.
///</summary>

public class SoundManager : MonoBehaviour
{
    public GameObject previoussource;
    public GameObject newsource;
    public bool is_active;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& is_active)
        {
            ChangeSound(previoussource,newsource);
        }
    }

    ///<summary>
    /// Change the music source
    ///<param Name = "previoussource"> The audio source which is playing </param>
    ///<param Name ="newsource"> The new audio source which will set active </param>
    ///</summary>
    private void ChangeSound(GameObject previoussource, GameObject newsource)
    {
        previoussource.SetActive(false);
        newsource.SetActive(true);
    }
}
