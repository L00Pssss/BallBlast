using UnityEngine;

public class ImmortalityCoin_Bonus : PikUp
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Cart cart = collision.transform.root.GetComponent<Cart>();

        if (cart != null)
        {
            cart.BonusImomortality = true;
        }
    }
}
