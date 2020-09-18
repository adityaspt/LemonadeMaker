using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public Sprite simpleLemonSprite;
    public Sprite sugarSprite;
    public Sprite waterSprite;
    public Sprite sodaSprite;
    public Sprite specialLemonSprite;

    // Update is called once per frame
    void Update()
    {
        
    }
}
