using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]
    private Transform itemSlotContainer;
    [SerializeField]
    private Transform itemSlotTemplate;
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }
    public void Awake()
    {
        itemSlotContainer = transform.Find("Image/ItemsParent");
        itemSlotTemplate = itemSlotContainer.Find("InventorySlot");

    }
    //private void RefreshInventoryItems()
    //{
    //    int x = 0; int y = 0;
    //    float itemSlotCellSize = 200f;
    //    foreach (Item.ItemType item in inventory.getItemsList())
    //    {

    //        RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
    //        itemSlotRectTransform.gameObject.SetActive(true);
    //        itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
    //        Image image = itemSlotRectTransform.Find("Icon").GetComponent<Image>();
    //        //image.sprite = item.GetItemSprite();
    //        x++;
    //        if (x > 4)
    //        {
    //            x = 0;
    //            y++;
    //        }
    //    }
    //}
    private void RefreshInventoryItems()
    {
        int x = 0; int y = 0;
        float itemSlotCellSize = 200f;
        foreach( KeyValuePair<Item.ItemType, int> item in inventory.getItemsList())
      
        {

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Icon").GetComponent<Image>();
            itemSlotRectTransform.Find("Number").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            image.sprite = Item.GetItemSprite(item.Key);
            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
