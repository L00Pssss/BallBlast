using UnityEngine;

public class Coin : PikUp
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        //Stone stone = collision.transform.root.GetComponent<Stone>(); // root ������� ������(��� ���� ��� �� ����������� �� �����).
       
        CartBag bag = collision.transform.root.GetComponent<CartBag>();

        if (bag != null)
        {
            bag.AddCoin(50);
        }
    }
}
