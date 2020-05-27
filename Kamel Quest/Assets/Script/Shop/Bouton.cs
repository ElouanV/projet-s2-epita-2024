using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Authors : Martin
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

    public GameObject sword;
    public GameObject shield;
    public GameObject armor;
    
    //UGRADE
    public int[] UGRADE_ARMURELVL = {100, 500, 1000, 101010};
    public int[] UGRADE_EPEELVL = {100, 500, 1000, 101010};
    public int[] UGRADE_BOUCLIERLVL = {100, 500, 1000, 101010};
    public int[] UGRADE_CASQUELVL = {100, 500, 1000, 101010};

    //ADD CARACTERISTIQUE
    public int[] ADD_ARMURE = {1, 5, 10, 101010};
    public int[] ADD_ATTACK = {2, 4, 12, 101010};
    public int[] ADD_HPMAX = {5, 500, 100, 101010};


    /// <summary>
    /// Fonction d'activation du texte
    /// </summary>
    /// <remarks>
    /// <para>Active le texte quand le curseur et sur le bouton </para>
    /// </remarks>
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


    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para>Soin </para>
    /// </remarks>
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

    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para>Potion de soin </para>
    /// </remarks>
    public void Equipement()
    {
      if(player.argent > 10)
      {
        player.argent -= 10;
        player1.GetComponent<Inventory_test>().AddToInventory(1, 1);
      }
    }

    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para>Gain d'argent (dev mode) </para>
    /// </remarks>

    public void Offrande42()
    {
        player.argent += 42;
    }

    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para> Amélioré l'épée </para>
    /// </remarks>

    public void Up_Epee()
    {
      if (player.epeelvl < 3 && player.argent > UGRADE_EPEELVL[player.epeelvl])
      {
        player.argent -= UGRADE_EPEELVL[player.epeelvl];
        player.atk += ADD_ATTACK[player.epeelvl];
        player.epeelvl += 1;
        sword.GetComponent<EquipementSlot>().Upgrade();
      } 
    }

    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para> Amélioré l'armure </para>
    /// </remarks>

    public void Up_Armure()
    {
      if (player.armurelvl < 3 && player.argent > UGRADE_ARMURELVL[player.armurelvl])
      {
        player.argent -= UGRADE_ARMURELVL[player.armurelvl];
        player.hpmax += ADD_HPMAX[player.armurelvl];
        player.armurelvl += 1;
        armor.GetComponent<EquipementSlot>().Upgrade();
      } 
    }

    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para> Amélioré le bouclier (pas dev) </para>
    /// </remarks>

    public void Up_Bouclier()
    {
      if (player.bouclierlvl < 3 && player.argent > UGRADE_BOUCLIERLVL[player.bouclierlvl])
      {
        player.argent -= UGRADE_BOUCLIERLVL[player.bouclierlvl];
        player.hpmax += ADD_HPMAX[player.bouclierlvl];
        player.bouclierlvl += 1;
        shield.GetComponent<EquipementSlot>().Upgrade();
      }
    }

    /// <summary>
    /// Bouton
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para> Amélioré le casque </para>
    /// </remarks>

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