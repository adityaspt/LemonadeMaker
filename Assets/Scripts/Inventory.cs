using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<Item.ItemType, int> itemsTracker;
    //public List<Item> itemList;
    public event EventHandler itemsBought;
    public Inventory()
    {
      

        itemsTracker = new Dictionary<Item.ItemType, int> ();
        //Starting items
        AddItem(Item.ItemType.SimpleLemon, 1);
        AddItem(Item.ItemType.Sugar, 1);
        AddItem(Item.ItemType.Water, 1);
        //
    }
    //public void AddItem(Item item)
    //{
    //    itemList.Add(item);
    //    itemsBought?.Invoke(this, EventArgs.Empty);
    //}
    public void AddItem(Item.ItemType itemType,int number)
    {

        itemsTracker.Add(itemType,number);
       // itemsBought?.Invoke(this, EventArgs.Empty);
    }

    //public List<Item> getItemsList()
    //{
    //    return itemList;
    //}
    public Dictionary<Item.ItemType,int> getItemsList()
    {
        return itemsTracker;
    }
}
