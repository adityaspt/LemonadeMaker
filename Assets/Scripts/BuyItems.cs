using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItems : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyItem(Item item)
    {
        
        AddItem(new Item { itemType = Item.ItemType.SimpleLemon, cost = 1, quantity = 1 });
    }
}
