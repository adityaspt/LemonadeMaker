using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Items")]
public class ItemScriptableObject :ScriptableObject
{
    public string itemName;
    public int cost;
    public float quantity;
    public Sprite itemImage;
}
