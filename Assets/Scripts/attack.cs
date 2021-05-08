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

    public bool isStun = false;
    public float stunTime = 0f;

    public bool isFreeze = false;
    public float freezeTime = 0f;
    public float freezeWeakness = 1f;

    public bool isPoison = false;
    public int poisonTime = 0;
    public float poisonDPS = 0;

    public bool isPillar = false;

    public bool isBlind = false;
    public float blindTime = 0f;

    public bool isWeakness = false;
    public float weaknessTime = 0f;

    public bool isSlowness = false;
    public float slownessTime = 0f;
    public float slownessEffect = 1f;


    public static float speedMultiplier = 1;
    public static float damageMultiplier = 1;

    public bool enemyLeft = false;

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
                if (other.gameObject.CompareTag("skeletonfs"))
                {
                    SkeletonFS enemy = other.gameObject.GetComponent<SkeletonFS>();
                    if (isPoison) { enemy.StartCoroutine(enemy.Poison(poisonTime, poisonDPS)); }
                    if(isWeakness) { enemy.StartCoroutine(enemy.Weakness(weaknessTime)); }
                    if(isSlowness) { enemy.StartCoroutine(enemy.Slowness(slownessTime, slownessEffect)); }
                    if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                else if (other.gameObject.CompareTag("skeletonmage"))
                {
                    SkeletonMage enemy = other.gameObject.GetComponent<SkeletonMage>();
                    if (isPoison) { enemy.StartCoroutine(enemy.Poison(poisonTime, poisonDPS)); }
                    if (isWeakness) { enemy.StartCoroutine(enemy.Weakness(weaknessTime)); }
                    if (isSlowness) { enemy.StartCoroutine(enemy.Slowness(slownessTime, slownessEffect)); }
                    if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                else if (other.gameObject.CompareTag("skeletontank"))
                {
                    SkeletonTank enemy = other.gameObject.GetComponent<SkeletonTank>();
                    if (isPoison) { enemy.StartCoroutine(enemy.Poison(poisonTime, poisonDPS)); }
                    if (isWeakness) { enemy.StartCoroutine(enemy.Weakness(weaknessTime)); }
                    if (isSlowness) { enemy.StartCoroutine(enemy.Slowness(slownessTime, slownessEffect)); }
                    if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                else if (other.gameObject.CompareTag("angelboss"))
                {
                    AngelBoss enemy = other.gameObject.GetComponent<AngelBoss>();
                    if (isPoison) { enemy.StartCoroutine(enemy.Poison(poisonTime, poisonDPS)); }
                    if (isWeakness) { enemy.StartCoroutine(enemy.Weakness(weaknessTime)); }
                    if (isSlowness) { enemy.StartCoroutine(enemy.Slowness(slownessTime, slownessEffect)); }
                    if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
            else
            {
                FindObjectOfType<AudioManager>().PlaySound("Bounce");
                transform.rotation =Quaternion.Euler(new Vector3(0, 0, 225));
                if (other.gameObject.CompareTag("skeletonfs"))
                {
                    SkeletonFS enemy = other.gameObject.GetComponent<SkeletonFS>();
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                else if (other.gameObject.CompareTag("skeletonmage"))
                {
                    SkeletonMage enemy = other.gameObject.GetComponent<SkeletonMage>();
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                else if (other.gameObject.CompareTag("skeletontank"))
                {
                    SkeletonTank enemy = other.gameObject.GetComponent<SkeletonTank>();
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                else if (other.gameObject.CompareTag("angelboss"))
                {
                    AngelBoss enemy = other.gameObject.GetComponent<AngelBoss>();
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
                isBouncy--;
                Vector2 inDirection = rigidbody2d.velocity;
                Vector2 inNormal = other.contacts[0].normal;
                Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal - new Vector2(0, -5));
                rigidbody2d.AddForce(newVelocity);
            }
        }
    }


    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            enemyLeft = false;
            if (other.gameObject.CompareTag("skeletonfs"))
            {
                SkeletonFS enemy = other.gameObject.GetComponent<SkeletonFS>();
                if (isStun) { enemy.StartCoroutine(enemy.Stun(stunTime)); }
                if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                if(isBlind) { enemy.StartCoroutine(enemy.Blind(blindTime)); }

                if (isPillar)
                {
                    while (!enemyLeft)
                    {
                        GetComponent<Animator>().SetBool("isAttack", true);
                        enemy.TakeDamage(damage);
                        yield return new WaitForSecondsRealtime(0.75f);
                    }
                    GetComponent<Animator>().SetBool("isAttack", false);
                }

                if (damage > 0) 
                {
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
            }
            else if ((!hitsEnemies) && (other.gameObject.CompareTag("skeletonmage")))
            {
                SkeletonMage enemy = other.gameObject.GetComponent<SkeletonMage>();
                if (isStun) { enemy.StartCoroutine(enemy.Stun(stunTime)); }
                if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                if (isBlind) { enemy.StartCoroutine(enemy.Blind(blindTime)); }

                if (isPillar)
                {
                    while (!enemyLeft)
                    {
                        enemy.TakeDamage(damage);
                        yield return new WaitForSecondsRealtime(0.75f);
                    }
                }

                if (damage > 0)
                {
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
            }
            else if ((!hitsEnemies) && (other.gameObject.CompareTag("skeletontank")))
            {
                SkeletonTank enemy = other.gameObject.GetComponent<SkeletonTank>();
                if (isStun) { enemy.StartCoroutine(enemy.Stun(stunTime)); }
                if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                if (isBlind) { enemy.StartCoroutine(enemy.Blind(blindTime)); }

                if (isPillar)
                {
                    while (!enemyLeft)
                    {
                        enemy.TakeDamage(damage);
                        yield return new WaitForSecondsRealtime(0.75f);
                    }
                }

                if (damage > 0)
                {
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
            }
            else if (other.gameObject.CompareTag("angelboss"))
            {
                AngelBoss enemy = other.gameObject.GetComponent<AngelBoss>();
                if (isStun) { enemy.StartCoroutine(enemy.Stun(stunTime)); }
                if (isFreeze) { enemy.StartCoroutine(enemy.Freeze(freezeTime, freezeWeakness)); }
                if (isBlind) { enemy.StartCoroutine(enemy.Blind(blindTime)); }

                if (isPillar)
                {
                    while (!enemyLeft)
                    {
                        enemy.TakeDamage(damage);
                        yield return new WaitForSecondsRealtime(0.75f);
                    }
                }

                if (damage > 0)
                {
                    damage *= damageMultiplier;
                    enemy.TakeDamage(damage);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            enemyLeft = true;
        }
    }



    void Update()
    {

    }

    IEnumerator wait(float life)
    {
        //Debug.Log(life);
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
