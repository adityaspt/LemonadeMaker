using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    Transform container;
    [SerializeField]
    Transform shopItemTemplate;

    [SerializeField]
    Transform cantBuyPanel;
    [SerializeField]
    Sprite checkMarkSprite;
    private void Awake()
    {
        container = transform.Find("Scroll View/Viewport/Content");
        if (gameObject.name == "Items")
        {
            shopItemTemplate = transform.Find("Scroll View/Viewport/Content/ItemsBuy");

        }
        else if (gameObject.name == "Recipies")
        {
            shopItemTemplate = transform.Find("Scroll View/Viewport/Content/RecipiesBuy");

        }
        shopItemTemplate.gameObject.SetActive(false);

        cantBuyPanel.gameObject.SetActive(false);

      
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Items")
        {
            CreateItemButton(Item.ItemType.SimpleLemon, Item.GetItemSprite(Item.ItemType.SimpleLemon), "Lemon", Item.GetItemCost(Item.ItemType.SimpleLemon), Item.GetItemQuantity(Item.ItemType.SimpleLemon), 0);
            CreateItemButton(Item.ItemType.Sugar, Item.GetItemSprite(Item.ItemType.Sugar), "Sugar", Item.GetItemCost(Item.ItemType.Sugar), Item.GetItemQuantity(Item.ItemType.Sugar), 1);
            CreateItemButton(Item.ItemType.Water, Item.GetItemSprite(Item.ItemType.Water), "Water", Item.GetItemCost(Item.ItemType.Water), Item.GetItemQuantity(Item.ItemType.Water), 2);
            CreateItemButton(Item.ItemType.Soda, Item.GetItemSprite(Item.ItemType.Soda), "Soda", Item.GetItemCost(Item.ItemType.Soda), Item.GetItemQuantity(Item.ItemType.Soda), 3);
            CreateItemButton(Item.ItemType.SpecialLemon, Item.GetItemSprite(Item.ItemType.SpecialLemon), "SpecialLemon", Item.GetItemCost(Item.ItemType.SpecialLemon), Item.GetItemQuantity(Item.ItemType.SpecialLemon), 4);
            CreateItemButton(Item.ItemType.SuperSugar, Item.GetItemSprite(Item.ItemType.SuperSugar), "SuperSugar", Item.GetItemCost(Item.ItemType.SuperSugar), Item.GetItemQuantity(Item.ItemType.SuperSugar), 5);
        }
        else if (gameObject.name == "Recipies")
        {
            CreateItemButton(Item.ItemType.SimpleRecipe, Item.GetItemSprite(Item.ItemType.SimpleRecipe), "SimpleRecipe", Item.GetItemCost(Item.ItemType.SimpleRecipe), Item.GetItemQuantity(Item.ItemType.SimpleRecipe), 0);
            CreateItemButton(Item.ItemType.SpecialRecipe, Item.GetItemSprite(Item.ItemType.SpecialRecipe), "SpecialRecipe", Item.GetItemCost(Item.ItemType.SpecialRecipe), Item.GetItemQuantity(Item.ItemType.SpecialRecipe), 1);
            CreateItemButton(Item.ItemType.SuperSpecialRecipe, Item.GetItemSprite(Item.ItemType.SuperSpecialRecipe), "SuperSpecialRecipe", Item.GetItemCost(Item.ItemType.SuperSpecialRecipe), Item.GetItemQuantity(Item.ItemType.SuperSpecialRecipe), 2);
        }
       
    }


    void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, float itemCost, float itemQuantity, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 300f;
        //shopItemRectTransform.anchoredPosition = new Vector2(0, shopItemHeight * positionIndex);
        shopItemRectTransform.anchoredPosition = new Vector2(0, (-shopItemHeight * positionIndex));
        if (itemType == Item.ItemType.SimpleRecipe)
        {
            shopItemTransform.Find("Button").GetComponent<Image>().sprite = checkMarkSprite;
           
        }
        
        else
        shopItemTransform.Find("Button").GetComponent<Image>().sprite = itemSprite;
        if (itemSprite.name == "bottle")
        {
            shopItemTransform.Find("Button").GetComponent<Image>().color = Color.blue;
        }
        shopItemTransform.Find("Button/Name").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Button/Quantity").GetComponent<TextMeshProUGUI>().SetText(itemQuantity.ToString());
        shopItemTransform.Find("Button/Cost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.gameObject.SetActive(true);
        shopItemTransform.Find("Button").GetComponent<Button>().onClick.AddListener(delegate { TryBuyItem(itemType); });


    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        if (itemType == Item.ItemType.SimpleRecipe || itemType == Item.ItemType.SpecialRecipe || itemType == Item.ItemType.SuperSpecialRecipe) //Check for recipes
        {
            if (Inventory.itemsTracker.ContainsKey(itemType))//already bought recipe
            {
                ShowCantBuyItem(1);
            }
            else //buy new recipe
            {
                CheckAndBuyItem(itemType);

            }


        }
        else //check for other items
        {

            CheckAndBuyItem(itemType);
        }
    }
   
    public void CheckAndBuyItem(Item.ItemType itemType)
    {
        if (PlayerPrefs.GetFloat(PlayerPrefsManager.currentMoney) >= Item.GetItemCost(itemType))
        {
            DeductCostOfItem(Item.GetItemCost(itemType));
            Inventory.itemsTracker.Add(itemType, 1);
        }
        else
        {
            //GameManager.gameManagerInstance.CantBuyItemEvent?.Invoke(this, EventArgs.Empty);
            ShowCantBuyItem(0);
           
        }
    }


    public void ShowCantBuyItem(int a)
    {
        
        cantBuyPanel.gameObject.SetActive(true);
       if(a==0)
            cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "You have no money to buy this !";
        else
        {
            cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "Already bought this!";
        }
    }
   
    public void DeductCostOfItem(float cost)
    {
        
        PlayerPrefs.SetFloat(PlayerPrefsManager.currentMoney, PlayerPrefs.GetFloat(PlayerPrefsManager.currentMoney) - cost);

    }

}
