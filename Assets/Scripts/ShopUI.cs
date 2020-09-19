using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    Transform container;
    [SerializeField]
    Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("Content");
        if (gameObject.name == "Items")
        {
            shopItemTemplate = transform.Find("Scroll View/Viewport/Content/ItemsBuy");
            if (shopItemTemplate != null)
            print("Found");
        }
        else if (gameObject.name == "Recipies")
        {
            shopItemTemplate = transform.Find("Scroll View/Viewport/Content/RecipiesBuy");

        }
        shopItemTemplate.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateItemButton(Item.GetItemSprite(Item.ItemType.SimpleLemon), "Lemon", Item.GetItemCost(Item.ItemType.SimpleLemon), Item.GetItemQuantity(Item.ItemType.SimpleLemon), 0);
        CreateItemButton(Item.GetItemSprite(Item.ItemType.Sugar), "Sugar", Item.GetItemCost(Item.ItemType.Sugar), Item.GetItemQuantity(Item.ItemType.Sugar), 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateItemButton(Sprite itemSprite,string itemName,float itemCost,float itemQuantity,int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        shopItemTransform.Find("Button/Name").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Button/Quantity").GetComponent<TextMeshProUGUI>().SetText(itemQuantity.ToString());
        shopItemTransform.Find("Button/Cost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.gameObject.SetActive(true);

    }
}
