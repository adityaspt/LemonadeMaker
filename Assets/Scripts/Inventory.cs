using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public static Dictionary<Item.ItemType, int> itemsTracker;
    //public List<Item> itemList;
   // public static event EventHandler OnItemsListChanged;
    public Inventory()
    {


        itemsTracker = new Dictionary<Item.ItemType, int>();
        //Starting items
        AddItem(Item.ItemType.SimpleRecipe, 1);
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
    public static void AddItem(Item.ItemType itemType, int number)
    {
        if (itemsTracker.ContainsKey(itemType))
        {
            if (Item.IsStackable(itemType))
            {
                itemsTracker[itemType] = itemsTracker[itemType] + 1;
            }
        }
        else
            itemsTracker.Add(itemType, number);
       // OnItemsListChanged?.Invoke(this, EventArgs.Empty);
        // itemsBought?.Invoke(this, EventArgs.Empty);
    }

    //public List<Item> getItemsList()
    //{
    //    return itemList;
    //}
    public Dictionary<Item.ItemType, int> getItemsList()
    {
        return itemsTracker;
    }
}
