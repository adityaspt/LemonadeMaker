using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookLemonade : MonoBehaviour
{
    public static event EventHandler orderIsReady;
    [SerializeField]
    Transform LemonadePlaceHolder;

    [SerializeField]
    Transform cantBuyPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void cook(string recipe)
    {
        int numberOfActive = 0;
        foreach(Transform child in LemonadePlaceHolder)
        {
            if (child.gameObject.activeSelf)
            {
                numberOfActive++;
            }
        }
        if (numberOfActive < 4)
        {
            if (recipe == Item.ItemType.SimpleRecipe.ToString())
            {
                checkIfRecipeIsBought(Item.ItemType.SimpleRecipe);
            }
            else if (recipe == Item.ItemType.SpecialRecipe.ToString())
            {
                checkIfRecipeIsBought(Item.ItemType.SpecialRecipe);
            }
            else if (recipe == Item.ItemType.SuperSpecialRecipe.ToString())
            {
                checkIfRecipeIsBought(Item.ItemType.SuperSpecialRecipe);
            }
        }
        else
        {
            cantBuyPanel.gameObject.SetActive(true);
            cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "Cant hold more than 4 lemonades";
        }
    }
    void checkIfRecipeIsBought(Item.ItemType itemType)
    {
        if (Inventory.itemsTracker.ContainsKey(itemType))
        {
            print("Can buy");
            CheckIfIngredientsAreCompleteAndRemoveFromList(itemType);
        }
        else
        {
            cantBuyPanel.gameObject.SetActive(true);
            cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "You need to buy this from shop to cook";
        }
    }

    void CheckIfIngredientsAreCompleteAndRemoveFromList(Item.ItemType itemType)
    {

        if (itemType == Item.ItemType.SimpleRecipe)
        {

            if (Inventory.itemsTracker.ContainsKey(Item.ItemType.SimpleLemon) && Inventory.itemsTracker.ContainsKey(Item.ItemType.Sugar) && Inventory.itemsTracker.ContainsKey(Item.ItemType.Water))
            {
                CheckAndDeductFromInventory(Item.ItemType.SimpleLemon);
                CheckAndDeductFromInventory(Item.ItemType.Sugar);
                CheckAndDeductFromInventory(Item.ItemType.Water);

              
                MakeAvailableToSell(itemType);
            }
            else
            {
                cantBuyPanel.gameObject.SetActive(true);
                cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "Cant make, Missing some ingredients";
                print("No ingredients");
            }

        }
        else if (itemType == Item.ItemType.SpecialRecipe)
        {

            if (Inventory.itemsTracker.ContainsKey(Item.ItemType.SpecialLemon) && Inventory.itemsTracker.ContainsKey(Item.ItemType.Sugar) && Inventory.itemsTracker.ContainsKey(Item.ItemType.Soda))
            {
                CheckAndDeductFromInventory(Item.ItemType.SpecialLemon);
                CheckAndDeductFromInventory(Item.ItemType.Sugar);
                CheckAndDeductFromInventory(Item.ItemType.Soda);
               


               
                MakeAvailableToSell(itemType);
            }
            else
            {
                cantBuyPanel.gameObject.SetActive(true);
                cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "Cant make, Missing some ingredients";
                print("No ingredients");
            }

        }
        else if (itemType == Item.ItemType.SuperSpecialRecipe)
        {

            if (Inventory.itemsTracker.ContainsKey(Item.ItemType.SpecialLemon) && Inventory.itemsTracker.ContainsKey(Item.ItemType.SuperSugar) && Inventory.itemsTracker.ContainsKey(Item.ItemType.Soda))
            {
                CheckAndDeductFromInventory(Item.ItemType.SpecialLemon);
                CheckAndDeductFromInventory(Item.ItemType.SuperSugar);
                CheckAndDeductFromInventory(Item.ItemType.Soda);
               
                MakeAvailableToSell(itemType);
            }
            else
            {
                cantBuyPanel.gameObject.SetActive(true);
                cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "Cant make, Missing some ingredients";
                print("No ingredients");
            }

        }


    }

    void CheckAndDeductFromInventory(Item.ItemType itemType)
    {
        if (Inventory.itemsTracker[itemType] > 1)
        {
            Inventory.itemsTracker[itemType] = Inventory.itemsTracker[itemType] - 1;
        }
        else if (Inventory.itemsTracker[itemType] <= 1)
            Inventory.itemsTracker.Remove(itemType);
    }


    void MakeAvailableToSell(Item.ItemType itemType)
    {
        foreach (Transform child in LemonadePlaceHolder)
        {
            if (!child.gameObject.activeSelf)
            {

                child.gameObject.SetActive(true);
                child.GetComponent<SellingOrder>().whatOrderIsThis = itemType;
                child.GetComponent<SpriteRenderer>().sprite = Item.GetItemSprite(itemType);

                break;
            }
        }
    }
}
