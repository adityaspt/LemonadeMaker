using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Inventory inventory;
    [SerializeField]
    InventoryUI inventoryUI;
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsManager.currentMoney))
        {
            PlayerPrefs.SetInt(PlayerPrefsManager.currentMoney, 5);
        }

        //inventory = new Inventory();
       // inventoryUI.SetInventory(inventory);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
