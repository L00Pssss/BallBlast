using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostCoin : PikUp
{
    [SerializeField] public Freez freez;
    //[SerializeField] public UIUpgrade uIUpgrade;
    [SerializeField] Stone stone;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        
        base.OnTriggerEnter2D(collision);

        

        Cart cart = collision.transform.root.GetComponent<Cart>();

        StoneSpawner stoneSpawner = GetComponent<StoneSpawner>();

    //    Freez freez = GetComponent<Freez>();

        if (cart != null)
        {
            freez.S();
        }
    }

}