using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFS : MonoBehaviour
{
    private GameObject Player;
    public GameObject enemySpawn;
    public float speed;
    public int maxHealth = 600;
    new Rigidbody2D rigidbody2D;
    public float fireRate = 1.0f;
    private float nextFire;
    public int expValue = 20;

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
            GameObject SkeletonFootSoldier = Instantiate(enemySpawn, rigidbody2D.position + Vector2.up * 4f, Quaternion.identity);
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
            GameManager.Instance.currentExp += expValue;
            Destroy(gameObject);
        }
    }


    void Update()
    {

    }
}

