using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
{
    public Entity entity;

    public void ChangeHp() 
    {
        
        entity.GetHeal (5);
    }
}
