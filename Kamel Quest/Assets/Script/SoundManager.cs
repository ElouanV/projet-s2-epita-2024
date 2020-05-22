using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void ChangeSound(GameObject previoussource, GameObject newsource)
    {
        previoussource.SetActive(false);
        newsource.SetActive(true);
    }
}
