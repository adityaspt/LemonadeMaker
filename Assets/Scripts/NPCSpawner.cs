using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField]
    Transform CustomerSpawnPos;

    [SerializeField]
    GameObject maleNpc, femaleNpc;
    public static bool CustomerhasCome=false;
    // Start is called before the first frame update


    public event EventHandler newCustomerhasCome;
    //public event EventHandler oldCustomerhasGone;
    public static NPCSpawner instance;
    float startTime;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        startTime = Time.time;
    }
    int counter;

    public void Count()
    {
        counter++;
        print(counter);

    }
    
    void Update()
    {
        if (Time.time - startTime >= 2)
        {


            startTime = Time.time;

            //if (maleNpc.activeSelf)
            //{
            //    oldCustomerhasGone?.Invoke(this, EventArgs.Empty);
            //    maleNpc.SetActive(false);
            //    return;
            //}
            //else if (femaleNpc.activeSelf)
            //{
            //    oldCustomerhasGone?.Invoke(this, EventArgs.Empty);
            //    femaleNpc.SetActive(false);

            //    return;
            //}

            if (!maleNpc.activeSelf && !femaleNpc.activeSelf)
            {

                int r = UnityEngine.Random.Range(0, 2);

                if (r == 0)
                {
                    maleNpc.SetActive(true);
                }
                else 
                {
                    femaleNpc.SetActive(true);
                }
                newCustomerhasCome?.Invoke(this, EventArgs.Empty);
                CustomerhasCome = true;
            }
        }
    }
}
