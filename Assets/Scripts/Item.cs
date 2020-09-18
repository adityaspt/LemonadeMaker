using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        SimpleLemon,Water,Soda,SpecialLemon,Sugar,SimpleRecipe,SpecialRecipe,
    }
    public ItemType itemType;
    public int cost;
    public float quantity;
    public Sprite GetItemSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.SimpleLemon:
                return ItemAssets.instance.simpleLemonSprite;
            case ItemType.Sugar:
                return ItemAssets.instance.sugarSprite;
            case ItemType.Soda:
                return ItemAssets.instance.sodaSprite;
            case ItemType.Water:
                return ItemAssets.instance.waterSprite;
            case ItemType.SpecialLemon:
                return ItemAssets.instance.specialLemonSprite;
        }
    }
}
