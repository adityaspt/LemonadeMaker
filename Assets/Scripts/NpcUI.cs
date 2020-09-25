using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NpcUI : MonoBehaviour
{
    public static NpcUI npcInstance;
    Transform orderCanvas;
    [SerializeField]
    List<Item.ItemType> RecipesThatCanBeOrdered;
    Transform dish;
    [SerializeField]
    public Item.ItemType orderedDish;


    // Start is called before the first frame update
    void Start()
    {
        NPCSpawner.instance.newCustomerhasCome += ShowOrderUI;
        //NPCSpawner.instance.oldCustomerhasGone+= RemoveOldOrderUI;
        SellingOrder.orderSold += RemoveOldOrderUI;
        orderCanvas = transform.Find("Canvas");
        RecipesThatCanBeOrdered = new List<Item.ItemType>();
        dish = orderCanvas.Find("Image/Dish");
        RecipesThatCanBeOrdered.Add(Item.ItemType.SimpleRecipe);
        orderedDish = Item.ItemType.SimpleRecipe;

    }

    private void OnEnable()
    {
        OrderableRecipesCheckAndPlaceInList();
    }

    void ShowOrderUI(object sender, EventArgs e)
    {
        //OrderableRecipesCheckAndPlaceInList();
        orderedDish = RecipesThatCanBeOrdered[UnityEngine.Random.Range(0, RecipesThatCanBeOrdered.Count)];

        dish.GetComponent<Image>().sprite = Item.GetItemSprite(orderedDish);
        orderCanvas.gameObject.SetActive(true);

    }
    void RemoveOldOrderUI(object sender, EventArgs e)
    {
        print("remove");
        orderCanvas.gameObject.SetActive(false);
        gameObject.SetActive(false);
        NPCSpawner.CustomerhasCome = false;
    }

    void OrderableRecipesCheckAndPlaceInList()
    {
        foreach (KeyValuePair<Item.ItemType, int> i in Inventory.itemsTracker)
        {
            print("items " + i.Key.ToString());
            if (i.Key == Item.ItemType.SimpleRecipe || i.Key == Item.ItemType.SpecialRecipe || i.Key == Item.ItemType.SuperSpecialRecipe)
            {
                print("Found recipe");
                if (!RecipesThatCanBeOrdered.Contains(i.Key))
                    RecipesThatCanBeOrdered.Add(i.Key);
            }
            else
            {
                print("NotFound recipe");
            }
        }
    }
}
