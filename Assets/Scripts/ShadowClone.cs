using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowClone : MonoBehaviour
{
    public float speed= 2;
    public float maxHealth = 300;
    new Rigidbody2D rigidbody2D;
    private float invincibleTime;
    private float invincibleCooldown = 3f;
    private GameObject Player;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "skeletonfs") || (collision.gameObject.tag == "skeletonmage") || (collision.gameObject.tag == "skeletontank"))
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, speed * Time.deltaTime);
            if (transform.position.x < Player.transform.position.x)
            {
                transform.rotation = Quaternion.identity;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "skeletonfs" && Time.time > invincibleTime)
        {
            //animator.SetTrigger("Hurt");
            invincibleTime = Time.time + invincibleCooldown;
            other.gameObject.GetComponent<SkeletonFS>().TakeDamage(50);
            TakeDamage(-50);
        }

        if (other.gameObject.tag == "skeletontank" && Time.time > invincibleTime)
        {
            //animator.SetTrigger("Hurt");
            invincibleTime = Time.time + invincibleCooldown;
            other.gameObject.GetComponent<SkeletonTank>().TakeDamage(50);
            TakeDamage(-100);
        }

        if (other.gameObject.tag == "skeletonmage" && Time.time > invincibleTime)
        {
            //animator.SetTrigger("Hurt");
            invincibleTime = Time.time + invincibleCooldown;
            other.gameObject.GetComponent<SkeletonTank>().TakeDamage(50);
            TakeDamage(-150);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mageattack" && Time.time > invincibleTime)
        {
            //animator.SetTrigger("Hurt");
            invincibleTime = Time.time + invincibleCooldown;
            TakeDamage(-200);
        }
    }


    void Update()
    {
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    void TakeDamage(int damage)
    {
        maxHealth += damage;
    }
}
