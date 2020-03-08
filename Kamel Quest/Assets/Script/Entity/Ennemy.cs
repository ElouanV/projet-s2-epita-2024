using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Entity
{
    public Ennemy(long hpmax,  int atk, string name, int magicatk, int atkcost)
    {
        this.hpmax = hpmax;
        this.atk = atk;
        this.name = name;
        this.magicatk = magicatk;
        this.atkcost = atkcost;
        this.currenthp = hpmax;
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
