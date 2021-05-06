using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour
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

    public static float sightRange = 6;

    public float damageMultiplier = 1f;
    public static float staticMultiplier = 1f;

    float hasStealthChanged;

    CoinDropper coinDropper;

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
        sightCollider.size = new Vector2(sightRange, 4f);
        coinDropper = GetComponent<CoinDropper>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > nextFire)
        {
            if (!isBlind && !playerInvis)
            {
                nextFire = Time.time + fireRate;
                GameObject mageAttack = Instantiate(mageFire, rigidbody2D.position + Vector2.up * 6f, Quaternion.identity);
            }
        }

       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (maxHealth == 0)
        //{
        //    Destroy(gameObject);
        //}
    }


    void Update()
    {
        if (hasStealthChanged != sightRange)
        {
            sightCollider.size = new Vector2(sightRange, 2f);
        }
        hasStealthChanged = sightRange;

        if (maxHealth <= 0)
        {
            GameManager.Instance.currentExp++;
            GameManager.Instance.currentExp++;
            coinDropper.coinDrop();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
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
        for (int i = 0; i <= poisonTime; i++)
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
