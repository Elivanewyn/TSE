using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFS : MonoBehaviour
{
    private GameObject Player;
    public float speed;
    public float maxHealth = 400;
    new Rigidbody2D rigidbody2D;
    private bool isBlind = false;
    public static bool playerInvis = false;

    public float damageMultiplier = 1f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isBlind && !playerInvis)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
            else if (isBlind)
            {
                System.Random multiplier = new System.Random();
                transform.position = Vector2.MoveTowards(transform.position, multiplier.Next(-4, 4) * Player.transform.position, speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "attack")
        {
            
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
        damage *= damageMultiplier;
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

    public IEnumerator Freeze(float freezeTime, float freezeWeakness)
    {
        damageMultiplier *= freezeWeakness;
        float temp = speed;
        speed *= 0.5f;
        yield return new WaitForSecondsRealtime(freezeTime);
        speed = temp;
        damageMultiplier = 1f;
    }

    public IEnumerator Poison(int poisonTime, float dps)
    {
        for(int i =0; i <= poisonTime; i++)
        {
            maxHealth -= dps;
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator Blind(float blindTime)
    {
        isBlind = true;
        yield return new WaitForSeconds(blindTime);
        isBlind = false;
    }

    public IEnumerator Weakness(float weakTime)
    {
        damageMultiplier *= 1.5f;
        yield return new WaitForSeconds(weakTime);
        damageMultiplier = 1f;
    }

    public IEnumerator Slowness(float slownessTime, float slownessEffect)
    {
        float temp = speed;
        speed *= slownessEffect;
        yield return new WaitForSeconds(slownessTime);
        speed = temp;
    }
}
