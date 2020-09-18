using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        SimpleLemon,Water,Soda,SpecialLemon,Sugar,SuperSugar,SimpleRecipe,SpecialRecipe,SuperSpecialRecipe,
    }
    public ItemType itemType;
    public int cost;
    public float quantity;
    public Sprite GetItemSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sugar:
                return ItemAssets.instance.sugarSprite;
            case ItemType.SimpleLemon:
                return ItemAssets.instance.simpleLemonSprite;
            case ItemType.Soda:
                return ItemAssets.instance.sodaSprite;
            case ItemType.Water:
                return ItemAssets.instance.waterSprite;
            case ItemType.SuperSugar:
                return ItemAssets.instance.superSugarSprite;
            case ItemType.SpecialLemon:
                return ItemAssets.instance.specialLemonSprite;
            case ItemType.SuperSpecialRecipe:
                return ItemAssets.instance.superSpecialRecipeSprite;
        }
    }
}
