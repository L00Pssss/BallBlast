using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : PikUp
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        //Stone stone = collision.transform.root.GetComponent<Stone>(); // root верхний объект(для того что бы достучаться до дестр).
       
        CartBag bag = collision.transform.root.GetComponent<CartBag>();

        if (/*stone != true &&*/ bag != null)
        {
            bag.AddCoin(50);
            //Debug.Log(bag.GetAmountKey());
        }
    }
}
