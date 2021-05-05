using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    public int xDirection = 1;
    private bool stopManualMove = false;

    public LayerMask enemyLayer;

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

    public Animator animator;
    public Animator particleAnimator;
    private float delayToIdle = 0.0f;

    public RuntimeAnimatorController knightAnimController;
    public RuntimeAnimatorController wizardAnimController;
    public RuntimeAnimatorController assassinAnimController;
    public RuntimeAnimatorController rangerAnimController;


    public GameObject particleL;
    public GameObject particleR;

    private static bool playerExists;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (PlayerCombat.currentClass.name == "Wizard")
        {
            animator.runtimeAnimatorController = wizardAnimController;
        }
        else if (PlayerCombat.currentClass.name == "Knight")
        {
            animator.runtimeAnimatorController = knightAnimController;
        }
        else if (PlayerCombat.currentClass.name == "Assassin")
        {
            animator.runtimeAnimatorController = assassinAnimController;
        }
        else if (PlayerCombat.currentClass.name == "Ranger")
        {
            animator.runtimeAnimatorController = rangerAnimController;
        }

        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        inventory.enabled = false;
        numberOfJumps = maxJumps;
        Time.timeScale = 1;

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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
        if(x2 > 0)
        {
            xDirection = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<PlayerCombat>().currentMelee = GetComponent<PlayerCombat>().meleeTransformR;
        }
        else if (x2 <0) 
        {
            xDirection = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<PlayerCombat>().currentMelee = GetComponent<PlayerCombat>().meleeTransformL;
        }
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

        if (other.gameObject.tag == "skeletonmage" && Time.time > nextInvincible)
        {
            //animator.SetTrigger("Hurt");
            nextInvincible = Time.time + invincibleTime;
            ChangeHealth(-3);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mageattack")
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
        yield return new WaitForSeconds(25);
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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange, pc.enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(75);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(75);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(75);
                }
            }
        }
        yield return new WaitForSeconds(1f);
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange, pc.enemyLayer);
        foreach (Collider2D enemy in hitEnemies2)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(150);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(150);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(150);
                }
            }
        }
        evadeChance = 0;
        stopManualMove = false;
    }


    public IEnumerator KnightDualSlice()
    {
        animator.SetTrigger("Skill6");
        rb2D.velocity = new Vector2(xDirection * 10f, rb2D.velocity.y + 10f);
        stopManualMove = true;
        PlayerCombat pc = GetComponent<PlayerCombat>();
        
        yield return new WaitForSeconds(1f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange, pc.enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(150);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(150);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(150);
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange, pc.enemyLayer);
        foreach (Collider2D enemy in hitEnemies2)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(150);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(150);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(150);
                }
            }
        }
        stopManualMove = false;
    }


    public IEnumerator KnightLionsRoar()
    {
        evadeChance += 30;
        yield return new WaitForSeconds(10);
        evadeChance -= 30;
    }

    public IEnumerator KnightBlessedTouch()
    {
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChangeHealth(0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator KnightMagicArmour()
    {
        float temp = speed;
        speed = 4;
        evadeChance += 70;
        yield return new WaitForSeconds(10);
        evadeChance -= 70;
        speed = temp;
    }

    public IEnumerator KnightAdrenlineRush()
    {
        evadeChance += 65;
        yield return new WaitForSeconds(10);
        evadeChance -= 65;
    }


    public IEnumerator KnightWarriorsSpirit()
    {
        defence += 0.1f;
        yield return new WaitForSeconds(10);
        defence -= 0.1f;
    }


    public IEnumerator KnightMothersPrayer()
    {
        PlayerCombat pc = GetComponent<PlayerCombat>();
        stopManualMove = true;
        pc.ChangeMana(2f);
        yield return new WaitForSeconds(1f);
        pc.ChangeMana(2f);
        yield return new WaitForSeconds(1f);
        pc.ChangeMana(2f);
        yield return new WaitForSeconds(1f);
        pc.ChangeMana(2f);
        yield return new WaitForSeconds(1f);
        pc.ChangeMana(2f);
        stopManualMove = false;
    }

    public IEnumerator KnightKnightsSpirit()
    {
        defence += 0.1f;
        yield return new WaitForSeconds(20);
        defence -= 0.1f;
    }


    public IEnumerator KnightSprint()
    {
        speed += 5;
        yield return new WaitForSeconds(8);
        speed -= 5;
    }

    public IEnumerator KnightSpringBoots()
    {
        jumpForce += 5;
        yield return new WaitForSeconds(8);
        jumpForce -= 5;
    }

    public IEnumerator KnightFeatherBoots()
    {
        float temp = fallMultiplier;
        fallMultiplier = 0.5f;
        yield return new WaitForSeconds(8);
        fallMultiplier = temp;
    }

    public IEnumerator KnightLightSpringBoots()
    {
        speed += 4;
        jumpForce += 4;
        yield return new WaitForSeconds(6);
        speed -= 4;
        jumpForce -= 4;
    }

    public IEnumerator KnightLightFeatherBoots()
    {
        float temp = fallMultiplier;
        fallMultiplier = 0.3f;
        speed += 4;
        yield return new WaitForSeconds(6);
        speed -= 4;
        fallMultiplier = temp;
    }


    public IEnumerator AssassinSlide()
    {
        rb2D.velocity = new Vector2(xDirection * 16f, rb2D.velocity.y);
        stopManualMove = true;
        evadeChance = 100;
        animator.SetTrigger("Slide");
        yield return new WaitForSeconds(1f);
        evadeChance = 0;
        stopManualMove = false;
    }


    public IEnumerator AssassinTaunt()
    {
        SkeletonFS.sightRange = 20;
        SkeletonMage.sightRange = 20;
        SkeletonTank.sightRange = 20;
        animator.SetTrigger("Taunt");
        yield return new WaitForSeconds(5f);
        SkeletonFS.sightRange = 3;
        SkeletonMage.sightRange = 3;
        SkeletonTank.sightRange = 3;
    }


    public IEnumerator AssassinAssassinate()
    {
        if(!isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -1 * 10);
            stopManualMove = true;
            evadeChance = 100;
            animator.SetTrigger("Assassinate");
            yield return new WaitForSeconds(0.85f);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(groundChecker.position, 1.5f, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().TakeDamage(400);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().TakeDamage(400);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().TakeDamage(400);
                    }
                }
            }
            evadeChance = 0;
            stopManualMove = false;
        }
    }

    public IEnumerator AssassinSlash()
    {
        rb2D.velocity = new Vector2(xDirection * 25f, rb2D.velocity.y);
        stopManualMove = true;
        evadeChance = 100;
        PlayerCombat pc = GetComponent<PlayerCombat>();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange, pc.enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(75);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(75);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(75);
                }
            }
        }
        animator.SetTrigger("PrimaryAttack");
        yield return new WaitForSeconds(1.2f);
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(pc.currentMelee.position, pc.meleeRange, pc.enemyLayer);
        foreach (Collider2D enemy in hitEnemies2)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(180);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(180);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(180);
                }
            }
        }
        evadeChance = 0;
        stopManualMove = false;
    }


    public IEnumerator AssassinShadowSneak()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        rb2D.velocity = 50 * GetComponent<PlayerCombat>().direction;
        stopManualMove = true;
        evadeChance = 100;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().enabled = true;
        evadeChance = 0;
        stopManualMove = false;
    }


    public IEnumerator AssassinOverHealth()
    {
        maxHealth = 20;
        ChangeHealth(10);
        yield return new WaitForSeconds(10f);
        maxHealth = 10;
        if(currentHealth - 10 <= 0)
        {
            if(currentHealth - 5 <= 0)
            {
                ChangeHealth(0);
            }
            else
            {
                ChangeHealth(-5);
            }
        }
        else
        {
            ChangeHealth(-10);
        }
    }


    public IEnumerator RangerSwiftBird()
    {
        speed += 5;
        fallMultiplier += 3;
        yield return new WaitForSeconds(8);
        speed -= 5;
        fallMultiplier -= 3;
    }

    public IEnumerator RangerRangersSoul()
    {
        attack.speedMultiplier = 1.5f;
        yield return new WaitForSeconds(8f);
        attack.speedMultiplier = 1;
    }

    public IEnumerator RangerSharpenedBlade()
    {
        SkeletonFS.staticMultiplier += 0.5f;
        SkeletonMage.staticMultiplier += 0.5f;
        SkeletonTank.staticMultiplier += 0.5f;
        yield return new WaitForSeconds(8f);
        SkeletonFS.staticMultiplier -= 0.5f;
        SkeletonMage.staticMultiplier -= 0.5f;
        SkeletonTank.staticMultiplier -= 0.5f;
    }

    public IEnumerator RangersHerbalRemedy()
    {
        while(currentHealth != maxHealth)
        {
            ChangeHealth(1f);
            yield return new WaitForSeconds(1);
        }
    }




    void AE_ResetRoll()
    {
        bool m_rolling;
        m_rolling = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundChecker == null) { return; }
        Gizmos.DrawWireSphere(groundChecker.position, checkGroundRadius);
    }

}
