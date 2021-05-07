using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBoss : MonoBehaviour
{
    private GameObject Player;
    public GameObject mageFire;
    public float speed;
    public int maxHealth = 400;
    new Rigidbody2D rigidbody2D;
    public float fireRate = 1.0f;
    private float nextFire;

    public bool isEnraged;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");

        isEnraged = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject mageAttack = Instantiate(mageFire, rigidbody2D.position + Vector2.up * 6f, Quaternion.identity);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
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
        if (maxHealth <= 500)
        {
            fireRate = nextFire/2;

        }
    }
}