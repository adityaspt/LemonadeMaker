using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcUI : MonoBehaviour
{
    Transform orderCanvas;
    // Start is called before the first frame update
    void Start()
    {
        NPC.instance.newCustomerhasCome += ShowOrderUI;
        NPC.instance.oldCustomerhasGone+= RemoveOldOrderUI;
        orderCanvas = transform.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowOrderUI(object sender,EventArgs e)
    {
        orderCanvas.gameObject.SetActive(true);
    }
    void RemoveOldOrderUI(object sender, EventArgs e)
    {
        orderCanvas.gameObject.SetActive(true);
    }
}
