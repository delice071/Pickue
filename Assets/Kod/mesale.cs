using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesale : MonoBehaviour
{
    public Sprite[] animasyonkareleri;
    SpriteRenderer spriterenderer;
    float zaman = 0;
    int animasyonsayaci=0;
   
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        zaman += Time.deltaTime;
        if(zaman > 0.1f)
        {
            spriterenderer.sprite = animasyonkareleri[animasyonsayaci++];
            if (animasyonkareleri.Length == animasyonsayaci)
            {
                animasyonsayaci = 0;
            }
            zaman = 0;
        }
    }
}
