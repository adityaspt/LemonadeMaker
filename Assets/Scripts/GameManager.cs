using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    Inventory inventory;
    [SerializeField]
    InventoryUI inventoryUI;

    [SerializeField]
    TextMeshProUGUI MoneyIndicatorText;

   
   
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey(PlayerPrefsManager.currentMoney))
        {
            PlayerPrefs.SetFloat(PlayerPrefsManager.currentMoney, 5);
        }
      
        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
       // CantBuyItemEvent += ShowCantBuyItem;
    }



    private void LateUpdate()
    {
        UpdateMoneyIndicator();
    }
    public void UpdateMoneyIndicator()
    {
        MoneyIndicatorText.text = PlayerPrefs.GetFloat(PlayerPrefsManager.currentMoney).ToString();
    }
  

}
