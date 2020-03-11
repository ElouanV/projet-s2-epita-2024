using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int argent;


    public Player (long hpmax,  int atk, string name, int magicatk, int atkcost, int argent)
    {
        this.hpmax = hpmax;
        this.atk = atk;
        this.name = name;
        this.magicatk = magicatk;
        this.atkcost = atkcost;
        this.currenthp = hpmax;
        this.argent = argent;

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
