using UnityEngine;

public class PikUp : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>(); // root ������� ������(��� ���� ��� �� ����������� �� �����).

        if (cart == true)
        {
            Destroy(gameObject);
        }
    }
}
