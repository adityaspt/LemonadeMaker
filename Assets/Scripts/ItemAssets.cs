using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance;
  
    void Awake()
    {
        instance = this;
    }

    public Sprite simpleLemonSprite;
    public Sprite sugarSprite;
    public Sprite waterSprite;
    public Sprite sodaSprite;
    public Sprite specialLemonSprite;
    public Sprite superSugarSprite;
    public Sprite simpleRecipeSprite;
    public Sprite specialRecipeSprite;
    public Sprite superSpecialRecipeSprite;




}
