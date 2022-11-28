using UnityEngine;

public class PikUp : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>(); // root верхний объект(для того что бы достучаться до дестр).

        if (cart == true)
        {
            Destroy(gameObject);
        }
    }
}
