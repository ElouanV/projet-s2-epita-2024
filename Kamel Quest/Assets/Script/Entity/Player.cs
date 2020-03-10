using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
<<<<<<< HEAD:Kamel Quest/Assets/Script/Entity/Player.cs

    public Player (long hpmax,  int atk, string name, int magicatk, int atkcost)
=======
    public int argent;
    public


    public Player (long hpmax,  int atk, string name, int magicatk, int atkcost, int argent)
>>>>>>> parent of 5b85fdea... Inrfeface + Bouton:Kamel Quest/Assets/Scenes/Script/Entity/Player.cs
    {
        this.hpmax = hpmax;
        this.atk = atk;
        this.name = name;
        this.magicatk = magicatk;
        this.atkcost = atkcost;
        this.currenthp = hpmax;
<<<<<<< HEAD:Kamel Quest/Assets/Script/Entity/Player.cs
=======
        this.argent = argent;

>>>>>>> parent of 5b85fdea... Inrfeface + Bouton:Kamel Quest/Assets/Scenes/Script/Entity/Player.cs
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
