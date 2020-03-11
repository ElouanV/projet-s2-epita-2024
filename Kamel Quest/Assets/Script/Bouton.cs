using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
{
    public Player player;
    public bool running = false;
    //public bool isclicked = false;
    //public int c = 0;


    /*public void Update()
    {
        if (running) 
        {
            StartCoroutine (ArgentIE10());
        }
    }

    IEnumerator ArgentIE10()
    {
        if (player.argent > 10)
        {
          player.argent -= 10;  
        }
        yield return new WaitForSeconds(7f);
        running = false;
    }*/

    public void PotionButton()
    {
      if(player.argent > 5)
      {
        if (player.hpmax - player.currenthp < 5)
        {
          player.currenthp = player.hpmax;
          player.argent -= 5;
        }
        else
        {
          player.currenthp += 5;
          player.argent -= 5; 
        }
        
      }
    }

    public void Equipement()
    {
      if(player.argent > 7)
      {
        player.hpmax += 10;
        player.argent -= 7;
      }
    }

    public void Offrande42()
    {
        player.argent += 42;
    }
}

// public void Update()
  //  {
   //     if (Input.GetMouseButtonDown(0) && !isclicked)
   //     {
  // //         isclicked = true;
   //         StartCoroutine(ChangeHp());
    //    }
  //  }
//
  //  IEnumerator ChangeHp() 
 //   {
   //     player.argent -= 10;
  //      player.currenthp += 10;

  // //     while (Input.GetMouseButtonDown(0))
  //      {
  //          yield return null;
  //      }
  //      isclicked = false;
  //  }