using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float life = 6;
    public float damage;
    public float speed;
    public bool hitsEnemies = true;
    public int isBouncy = 0;

    public static float speedMultiplier = 1;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        StartCoroutine(wait(life));
    }

    public void Launch(Vector2 direction)
    {
        speed = speed * speedMultiplier;
        rigidbody2d.AddForce(direction * speed);
    }

    public void Throw(Vector2 direction)
    {
        speed = speed * speedMultiplier;
        rigidbody2d.AddForce(Vector2.up * 200);
        rigidbody2d.AddForce(direction * speed);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (isBouncy <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                isBouncy--;
                Vector2 inDirection = rigidbody2d.velocity;
                Vector2 inNormal = other.contacts[0].normal;
                Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal - new Vector2(0, -5));
                rigidbody2d.AddForce(newVelocity);
            }
        }
    }

    void Update()
    {
        speed = speed * speedMultiplier;
    }

    IEnumerator wait(float life)
    {
        //Debug.Log(life);
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
