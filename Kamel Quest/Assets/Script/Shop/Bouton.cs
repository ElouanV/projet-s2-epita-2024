using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
{
    public Player player;
    public bool running = false;
    public GameObject potion;
    public Sprite healPotionSprite;
    public GameObject player1;

    public GameObject DescriptionArmure;
    public GameObject DescriptionEpee;
    public GameObject DescriptionBouclier;
    public GameObject DescriptionCasque;
    //Information du shop (Text)
    
    //UGRADE
    public int[] UGRADE_ARMURELVL = {100, 500, 1000};
    public int[] UGRADE_EPEELVL = {100, 500, 1000};
    public int[] UGRADE_BOUCLIERLVL = {100, 500, 1000};
    public int[] UGRADE_CASQUELVL = {100, 500, 1000};

    //ADD CARACTERISTIQUE
    public int[] ADD_ARMURE = {1, 5, 10};
    public int[] ADD_ATTACK = {2, 4, 12};
    public int[] ADD_HPMAX = {5, 500, 100};

    //DESCRIPTION
    public void ActiveTextArmure ()
    {
        DescriptionArmure.SetActive(true);
    }

    public void DisableTextArmure ()
    {
        DescriptionArmure.SetActive(false);   
    }

    public void ActiveTextEpee ()
    {
        DescriptionEpee.SetActive(true);
    }

    public void DisableTextEpee ()
    {
        DescriptionEpee.SetActive(false);   
    }

    public void ActiveTextBouclier ()
    {
        DescriptionBouclier.SetActive(true);
    }

    public void DisableTextBouclier ()
    {
        DescriptionBouclier.SetActive(false);   
    }

    public void ActiveTextCasque ()
    {
        DescriptionCasque.SetActive(true);
    }

    public void DisableTextCasque ()
    {
        DescriptionCasque.SetActive(false);   
    }

    //Information du shop
    public int If_I_Up_Armure()
    {
      return (ADD_ARMURE[player.armurelvl]); 
    }

    public int Cost_Up_Armure()
    {
      return (UGRADE_ARMURELVL[player.armurelvl]);
    }

     public int If_I_Up_Epee()
     {
      return (ADD_ATTACK[player.epeelvl]);
     }

    public int Cost_Up_Epee()
    {
      return (UGRADE_EPEELVL[player.epeelvl]);
    }


   public int If_I_Up_Bouclier()
   {
      return (ADD_HPMAX[player.bouclierlvl]);
   }

    public int Cost_Up_Bouclier()
    {
      return (UGRADE_BOUCLIERLVL[player.bouclierlvl]);
    }


   public int If_I_Up_Casque()
   {
     return (ADD_ARMURE[player.armurelvl]);
   }
   
    public int Cost_Up_Casque()
    {
      return (UGRADE_CASQUELVL[player.casquelvl]);
    }


   
    //BOUTONS
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
        player1.GetComponent<Inventory_test>().AddToInventory(1, "potion", 1, "potion", healPotionSprite);
      }
    }

    public void Offrande42()
    {
        player.argent += 42;
    }

    public void Up_Epee()
    {
      if (player.epeelvl < 3 && player.argent > UGRADE_EPEELVL[player.epeelvl])
      {
        player.argent -= UGRADE_EPEELVL[player.epeelvl];
        player.atk += ADD_ATTACK[player.epeelvl];
        player.epeelvl += 1;
      } 
    }

    public void Up_Armure()
    {
      if (player.armurelvl < 3 && player.argent > UGRADE_ARMURELVL[player.armurelvl])
      {
        player.argent -= UGRADE_ARMURELVL[player.armurelvl];
        player.hpmax += ADD_HPMAX[player.armurelvl];
        player.armurelvl += 1;
      } 
    }

    public void Up_Bouclier()
    {
      if (player.bouclierlvl < 3 && player.argent > UGRADE_BOUCLIERLVL[player.bouclierlvl])
      {
        player.argent -= UGRADE_BOUCLIERLVL[player.bouclierlvl];
        player.hpmax += ADD_HPMAX[player.bouclierlvl];
        player.bouclierlvl += 1;
      }
    }

    public void Up_Casque()
    {
      if (player.casquelvl < 3 && player.argent > UGRADE_CASQUELVL[player.casquelvl])
      {
        player.argent -= UGRADE_CASQUELVL[player.casquelvl];
        player.atk += ADD_ARMURE[player.casquelvl];
        player.casquelvl += 1;
      } 
    }
}