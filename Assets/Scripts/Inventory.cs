using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> itemList;
    public event EventHandler itemsBought;
    public Inventory()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.SimpleLemon, cost = 1, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Water, cost = 2, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Sugar, cost = 2, quantity = 20 });

        
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
        itemsBought?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> getItemsList()
    {
        return itemList;
    }
}
