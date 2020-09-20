using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public enum ItemType
    {
        SimpleLemon, Water, Soda, SpecialLemon, Sugar, SuperSugar, SimpleRecipe, SpecialRecipe, SuperSpecialRecipe,
    }
    public static ItemType itemType;
    //public int cost;
    //public float quantity;
    public static Sprite GetItemSprite(ItemType itemType)
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
            case ItemType.SpecialRecipe:
                return ItemAssets.instance.specialRecipeSprite;
            case ItemType.SimpleRecipe:
                return ItemAssets.instance.simpleRecipeSprite;
        }
    }
    public static float GetItemCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Sugar:
                return 2f;
            case ItemType.SimpleLemon:
                return 0.5f;
            case ItemType.Soda:
                return 5f;
            case ItemType.Water:
                return 2f;
            case ItemType.SuperSugar:
                return 8f;
            case ItemType.SpecialLemon:
                return 6f;
            case ItemType.SuperSpecialRecipe:
                return 15;
            case ItemType.SpecialRecipe:
                return 10;
            case ItemType.SimpleRecipe:
                return 5f;
        }
    }
    public static float GetItemQuantity(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Sugar:
                return 1;
            case ItemType.SimpleLemon:
                return 1f;
            case ItemType.Soda:
                return 1f;
            case ItemType.Water:
                return 1f;
            case ItemType.SuperSugar:
                return 1;
            case ItemType.SpecialLemon:
                return 1f;
            case ItemType.SuperSpecialRecipe:
                return 1;
            case ItemType.SpecialRecipe:
                return 1;
            case ItemType.SimpleRecipe:
                return 1f;
        }
    }
    public static bool IsStackable(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Sugar:

            case ItemType.SimpleLemon:

            case ItemType.Soda:

            case ItemType.Water:

            case ItemType.SuperSugar:
            case ItemType.SpecialLemon:
                return true;
            case ItemType.SuperSpecialRecipe:
                
            case ItemType.SpecialRecipe:
                
            case ItemType.SimpleRecipe:
                return false;
        }
    }
}
