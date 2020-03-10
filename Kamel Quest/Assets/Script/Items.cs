using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount;

    public Items (int ID, string name, string description,int count)
    {
        this.itemID = ID;
        this.itemName = name;
        this.itemDescription = description;
        this.itemCount = count;
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
