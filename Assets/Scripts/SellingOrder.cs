using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellingOrder : MonoBehaviour
{
    // public static SellingOrder sellingInstance;
    [SerializeField]
    public Item.ItemType whatOrderIsThis;
    public static event EventHandler orderSold;
    [SerializeField]
    Transform maleNpc, femaleNpc;

    [SerializeField]
    Transform currentCustomer;
    [SerializeField]
    Transform cantBuyPanel;


    // Start is called before the first frame update
    void Start()
    {
        // NPCSpawner.instance.newCustomerhasCome += SetOrder;
    }




    private void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && NPCSpawner.CustomerhasCome )
        {

            if (gameObject.activeSelf)
            {
                checkWhichNPCIsActive();
                if (currentCustomer.GetComponent<NpcUI>().orderedDish == whatOrderIsThis)
                {
                    orderSold?.Invoke(this, EventArgs.Empty);
                    getOrderMoney(whatOrderIsThis);
                    print(whatOrderIsThis.ToString() + " Sold");

                    gameObject.SetActive(false);
                    // print("sold");
                }
                else
                {
                    print("wrong lemonade");
                    cantBuyPanel.GetComponent<Transform>().Find("Image/CantBuyText").GetComponent<TextMeshProUGUI>().text = "Wrong Lemonade !";
                    print("No ingredients");
                }
            }
        }
    }
    void getOrderMoney(Item.ItemType itemType)
    {
        PlayerPrefs.SetFloat(PlayerPrefsManager.currentMoney, PlayerPrefs.GetFloat(PlayerPrefsManager.currentMoney) + Item.ItemSellingPrice(itemType));
    }

    void checkWhichNPCIsActive()
    {
        if (maleNpc.gameObject.activeSelf)
        {
            currentCustomer = maleNpc;
        }
        else
        {
            currentCustomer = femaleNpc;
        }
    }
}
