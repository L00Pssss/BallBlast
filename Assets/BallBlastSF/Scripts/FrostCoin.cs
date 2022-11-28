using UnityEngine;

public class FrostCoin : PikUp
{
    [SerializeField] public Freez freez;
    [SerializeField] Stone stone;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        
        base.OnTriggerEnter2D(collision);

        Cart cart = collision.transform.root.GetComponent<Cart>();

        StoneSpawner stoneSpawner = GetComponent<StoneSpawner>();

        if (cart != null)
        {
            freez.S();
        }
    }

}