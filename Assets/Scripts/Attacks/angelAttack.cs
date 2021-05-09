using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelAttack : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private GameObject Player;
    public float speed;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}