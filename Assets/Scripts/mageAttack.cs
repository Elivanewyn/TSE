using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageAttack : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private GameObject Player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
