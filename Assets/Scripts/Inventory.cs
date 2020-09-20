using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<Item.ItemType, int> itemsTracker=new Dictionary<Item.ItemType, int>();
    public List<Item.ItemType> itemList;
    public event EventHandler itemsBought;
    public Inventory()
    {
        itemList = new List<Item.ItemType>();
        //AddItem(new Item { itemType = Item.ItemType.SimpleLemon, cost = 1, quantity = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Water, cost = 2, quantity = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Sugar, cost = 2, quantity = 20 });
        
        //AddItem(new Item { Item.ItemType.Water, cost = 2, quantity = 1 });
        //AddItem(new Item {  Item.ItemType.Sugar, cost = 2, quantity = 20 });


    }
    //public void AddItem(Item item)
    //{
    //    itemList.Add(item);
    //    itemsBought?.Invoke(this, EventArgs.Empty);
    //}
    //public void AddItem(Item.ItemType itemType)
    //{
       
    //   // itemList.Add(itemType);
    //    //itemsBought?.Invoke(this, EventArgs.Empty);
    //}

    //public List<Item.ItemType> getItemsList()
    //{
    //    return itemList;
    //}
}
