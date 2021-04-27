﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    private int xDirection = 1;
    private bool stopManualMove = false;

    public float speed = 7.0f;
    public float jumpForce = 6.0f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    public float maxHealth = 10;
    public float health { get { return currentHealth; } set { value = currentHealth; } }
    float currentHealth;

    public float defence = 0.1f;

    bool isGrounded = false;
    public Transform groundChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float rememberGrounded;
    private float lastTimeGrounded;
    public float invincibleTime = 1.0f;
    private float nextInvincible;

    public Canvas inventory;

    public int evadeChance = 0;

    public int maxJumps = 1;
    int numberOfJumps;

    private Animator animator;
    private float delayToIdle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        inventory.enabled = false;
        numberOfJumps = maxJumps;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckGrounded();
        animator.SetFloat("AirSpeedY", rb2D.velocity.y);


        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    ChangeHealth(-1f);
        //}

        if(Input.GetKeyDown(KeyCode.F) && (inventory.enabled))
        {
            Time.timeScale = 1f;
            inventory.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0.0f;
            
            inventory.enabled = true;
        }


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }




    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float x2 = Input.GetAxis("Horizontal");
        if(x2 > 0) { xDirection = 1; GetComponent<SpriteRenderer>().flipX = false; }
        else if (x2 <0) { xDirection = -1; GetComponent<SpriteRenderer>().flipX = true; }
        float moveBy = x * speed;
        if (!stopManualMove)
        {
            rb2D.velocity = new Vector2(moveBy, rb2D.velocity.y);
        }


        if (Mathf.Abs(x2) > Mathf.Epsilon)
        {
            delayToIdle = 0.05f;
            animator.SetInteger("AnimState", 1);
        }

        else
        {
            delayToIdle -= Time.deltaTime;
            if (delayToIdle < 0)
                animator.SetInteger("AnimState", 0);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && ((isGrounded || Time.time - lastTimeGrounded <= rememberGrounded) || (numberOfJumps > 1)))
        {
            animator.SetTrigger("Jump");
            animator.SetBool("Grounded", false);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            numberOfJumps--;
        }
    }

    void CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);

        if(collider != null) 
        {
            isGrounded = true;
            numberOfJumps = maxJumps;
            animator.SetBool("Grounded", isGrounded);
        }
        else
        {
            if(isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
            animator.SetBool("Grounded", isGrounded);
        }
    }

    void BetterJump()
    {
        if(rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void ChangeHealth(float amount)
    {
        if(amount < 0)
        {
            amount += defence;
        }

        if(amount < 0 && evadeChance > 0)
        {
            System.Random rnd = new System.Random();
            int rndNum = rnd.Next(1, 100);
            if(rndNum <= evadeChance)
            {
                amount = 0;
            }
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0f, maxHealth);
        UIBar.health.SetValue(currentHealth / (float)maxHealth);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "skeletonfs" && Time.time > nextInvincible)
        {
            //animator.SetTrigger("Hurt");
            nextInvincible = Time.time + invincibleTime;
            ChangeHealth(-2);
        }

        if (other.gameObject.tag == "skeletontank" && Time.time > nextInvincible)
        {
            //animator.SetTrigger("Hurt");
            nextInvincible = Time.time + invincibleTime;
            ChangeHealth(-1);
        }

        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "skeletonmage")
        {
            //animator.SetTrigger("Hurt");
            ChangeHealth(-3);
        }
    }




    public IEnumerator WizardSpeedBoost()
    {
        speed += 3;
        yield return new WaitForSeconds(8);
        speed -= 3;
    }
    public IEnumerator WizardEvasionAmplification()
    {
        evadeChance += 10;
        yield return new WaitForSeconds(15);
        evadeChance -= 10;
    }

    public IEnumerator WizardDefenceBoost()
    {
        defence += 0.1f;
        yield return new WaitForSeconds(15);
        defence -= 0.1f;
    }

    public IEnumerator KnightRoll()
    {
        animator.SetTrigger("Roll");
        rb2D.velocity = new Vector2(xDirection * 6f, rb2D.velocity.y);
        stopManualMove = true;
        evadeChance = 100;
        yield return new WaitForSeconds(0.5f);
        evadeChance = 0;
        stopManualMove = false;
    }


    public IEnumerator KnightLunge()
    {
        animator.SetTrigger("Skill5");
        rb2D.velocity = new Vector2(xDirection * 6f, rb2D.velocity.y);
        stopManualMove = true;
        evadeChance = 100;
        PlayerCombat pc = GetComponent<PlayerCombat>();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pc.meleeTransform.position, pc.meleeRange, pc.enemyLayer);
        yield return new WaitForSeconds(1f);
        foreach(Collider2D enemy in hitEnemies)
        {

            if(enemy.tag == "skeletonfs")
            {
                enemy.GetComponent<SkeletonFS>().TakeDamage(150);
            }
            if(enemy.tag == "skeletonmage")
            {
                //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
            }
            if (enemy.tag == "skeletontank")
            {
                //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
            }
        }
        evadeChance = 0;
        stopManualMove = false;
    }



    void AE_ResetRoll()
    {
        bool m_rolling;
        m_rolling = false;
    }
    
}
