using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelCombat : MonoBehaviour
{
    public int health = 500;
    public bool isInvulnerable = false;
    public bool enraged = false;

    private GameObject Player;
    public GameObject AngelAttack;
    new Rigidbody2D rigidbody2D;
    public float fireRate = 1.0f;
    private float nextFire;
    public int attackDamage = 2;
    

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }
    
    
    public void takeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            enraged = true;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject AngelWeapon = Instantiate(AngelAttack, rigidbody2D.position + Vector2.up * 6f, Quaternion.identity);
        }
    }

    


}
