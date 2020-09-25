using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance;
  
    void Awake()
    {
        instance = this;

        //simpleLemonSprite  = Resources.Load<Sprite>("Items/lemon");
        //sugarSprite = Resources.Load<Sprite>("Items/sugar");
        //waterSprite = Resources.Load<Sprite>("Items/bottle");
        //sodaSprite = Resources.Load<Sprite>("Items/soda");
        //specialLemonSprite = Resources.Load<Sprite>("Items/specialLemon");
        //superSugarSprite = Resources.Load<Sprite>("Items/superSugar");
        //simpleRecipeSprite = Resources.Load<Sprite>("Items/simpleLemonade");
        //specialRecipeSprite = Resources.Load<Sprite>("Items/SpecialLemonade");
        //superSpecialRecipeSprite = Resources.Load<Sprite>("Items/SuperSpecialRecipe");
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
