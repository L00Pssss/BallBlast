using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectial : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private int damage;



    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructible destructible = collision.transform.root.GetComponent<Destructible>(); // root ������� ������(��� ���� ��� �� ����������� �� �����).

        if (destructible != null)
        {
            destructible.ApplyDamage(damage);
        }
        Destroy(gameObject);
        
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
