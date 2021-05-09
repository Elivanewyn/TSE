using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBoss : MonoBehaviour
{
    private GameObject Player;
    public GameObject mageFire;
    public float speed;
    public float maxHealth = 400;
    new Rigidbody2D rigidbody2D;
    public float fireRate = 1.0f;
    private float nextFire;

    private bool isBlind = false;
    public static bool playerInvis = false;

    static BoxCollider2D sightCollider;

    public static float sightRange = 8;

    public float damageMultiplier = 1f;
    public static float staticMultiplier = 1f;

    float hasStealthChanged;

    public bool isEnraged;

    CanScript canScript;

    void Start()
    {
        hasStealthChanged = sightRange;
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");

        BoxCollider2D[] bc2d = GetComponents<BoxCollider2D>();
        if (bc2d[0].isTrigger)
        {
            sightCollider = bc2d[0];
        }
        else
        {
            sightCollider = bc2d[1];
        }
        sightCollider.size = new Vector2(sightRange, 6f);

        isEnraged = false;

        canScript = GameObject.Find("Canvas").GetComponent<CanScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > nextFire)
        {
            if (!isBlind && !playerInvis)
            {
                nextFire = Time.time + fireRate;
                GameObject mageAttack = Instantiate(mageFire, rigidbody2D.position + Vector2.up * 6f, Quaternion.identity);
                if (transform.position.x > Player.transform.position.x)
                {
                    transform.rotation = Quaternion.identity;
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "attack")
        //{
        //    maxHealth -= 200;
        //}


        if (maxHealth == 0)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (hasStealthChanged != sightRange)
        {
            sightCollider.size = new Vector2(sightRange, 2f);
        }
        hasStealthChanged = sightRange;

        if (maxHealth <= 500)
        {
            fireRate = nextFire/2;

        }

        if (maxHealth <= 0)
        {
            CanScript.bossDead = true;
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        FindObjectOfType<AudioManager>().PlaySound("PrimaryAttack");
        damage *= damageMultiplier * staticMultiplier;
        maxHealth -= damage;
    }

    public IEnumerator Stun(float stunTime)
    {
        float temp = nextFire;
        nextFire = Time.time + 1000;
        yield return new WaitForSecondsRealtime(stunTime);
        nextFire = temp;
    }

    public IEnumerator Freeze(float freezeTime, float freezeWeakness)
    {
        damageMultiplier = freezeWeakness;
        float temp = fireRate;
        fireRate *= 2f;
        yield return new WaitForSecondsRealtime(freezeTime);
        fireRate = temp;
        damageMultiplier = 1f;
    }

    public IEnumerator Poison(int poisonTime, float dps)
    {
        for (int i = 0; i <= 5; i++)
        {
            if (maxHealth - dps > 0)
            {
                maxHealth -= dps;
            }
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
        float temp = fireRate;
        fireRate *= 2;
        yield return new WaitForSeconds(slownessTime);
        fireRate = temp;
    }


}