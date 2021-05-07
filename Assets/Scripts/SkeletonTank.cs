using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTank : MonoBehaviour
{
    private GameObject Player;
    public float speed;
    public float maxHealth = 800;
    new Rigidbody2D rigidbody2D;
    private bool isBlind = false;
    public static bool playerInvis = false;

    static BoxCollider2D sightCollider;

    public static float sightRange = 7;//??

    public float damageMultiplier = 1f;
    public static float staticMultiplier = 1f;
    public Animator animator;

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
        sightCollider.size = new Vector2(sightRange, 2f);//??
        coinDropper = GetComponent<CoinDropper>();
        animator = GetComponent<Animator>();
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
                        
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1);
        coinDropper.coinDrop();
        GameManager.Instance.currentExp++;
        GameManager.Instance.currentExp++;
        GameManager.Instance.currentExp++;
        Die();

    }

    void Die()
    {
        
        
        Debug.Log("Enemy died!");       
        Destroy(gameObject);        
        this.enabled = false;

    }

    public void TakeDamage(float damage)
    {
        FindObjectOfType<AudioManager>().PlaySound("PrimaryAttack");
        damage *= damageMultiplier * staticMultiplier;
        maxHealth -= damage;
    }



    public IEnumerator Stun(float stunTime)
    {
        float temp = speed;
        speed = 0;
        yield return new WaitForSecondsRealtime(stunTime);
        speed = temp;
    }

    public IEnumerator Freeze(float freezeTime, float freezeWeakness)
    {
        damageMultiplier = freezeWeakness;
        float temp = speed;
        speed *= 0.5f;
        yield return new WaitForSecondsRealtime(freezeTime);
        speed = temp;
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
        float temp = speed;
        speed *= slownessEffect;
        yield return new WaitForSeconds(slownessTime);
        speed = temp;
    }
}
