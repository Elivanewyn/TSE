using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTest : MonoBehaviour
{
    private GameObject Player;
    public GameObject angelfire;
    public float speed;
    public int maxHealth = 400;
    new Rigidbody2D rigidbody2D;
    public float fireRate = 1.0f;
    private float nextFire;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject angelAttack = Instantiate(angelfire, rigidbody2D.position + Vector2.up * 6f, Quaternion.identity);
        }


    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "attack")
        {
            maxHealth -= 200;
        }


        if (maxHealth == 0)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {

    }
}

