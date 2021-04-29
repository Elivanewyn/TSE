using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFS : MonoBehaviour
{
    private GameObject Player;
    public float speed;
    public float maxHealth = 400;
    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
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
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
    }

    public IEnumerator Stun(float stunTime)
    {
        Debug.Log("test");
        float temp = speed;
        speed = 0;
        yield return new WaitForSecondsRealtime(stunTime);
        speed = temp;
    }
}
