using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField] float gravity;

    private void Update()
    {
        Move();
    }



    private void Move()
    {
        velocity.y -= gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>(); // получаем грань 

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                enabled = false;
            }
        }
    }
}
