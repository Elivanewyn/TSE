using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{

    public static ClassSystem.PlayerClass currentClass = ClassSystem.assassin;
    public static ClassSystem.Skill equippedSkill1;
    public static ClassSystem.Skill equippedSkill2;
    public Image skill1Portrait;
    public Image skill2Portrait;
    public static ClassSystem.Weapon equippedWeapon;

    public float cooldown1;
    private float cooldownTime1;
    public float cooldown2;
    private float cooldownTime2;

    public float rechargeRate = 1.0f;
    private float nextRecharge;

    public float maxMana = 20;
    public float mana { get { return currentMana; } }
    float currentMana;

    Rigidbody2D rb2D;

    public Vector2 direction;

    public SpriteRenderer playerSprite;
    public Transform meleeTransformR;
    public Transform meleeTransformL;
    public Transform currentMelee;
    public float meleeRange = 0.5f;
    public LayerMask enemyLayer;


    private int tripleSwipeNumber = 0;
    private float timeSinceTripleSwipe = 0.0f;
    private float timeSincePrimary = 0.0f;

    bool start = false;

    // PrimaryAttack animator
    public Animator animator;
    public int attackDamage = 40;
    public float attackRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;


        equippedSkill1 = currentClass.basicSkills[0];
        equippedSkill2 = currentClass.basicSkills[1];
        equippedWeapon = currentClass.weapons[0];

        skill1Portrait.sprite = equippedSkill1.portrait;
        skill2Portrait.sprite = equippedSkill2.portrait;


        cooldown1 = equippedSkill1.cooldown;
        cooldown2 = equippedSkill2.cooldown;

        cooldownTime1 = 0;
        cooldownTime2 = 0;
        nextRecharge = rechargeRate;

        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        player.maxHealth = currentClass.strength * 10;
        player.health = player.maxHealth;
        player.defence = currentClass.defence;
        maxMana = currentClass.intelligence * 20;
        currentMana = maxMana;

        if (currentClass.dext == 1)
        {
            player.speed = 8f;
            player.jumpForce = 8.0f;
        }
        else if (currentClass.dext == 2)
        {
            player.speed = 10.5f;
            player.jumpForce = 10f;
        }
        else if (currentClass.dext == 3)
        {
            player.speed = 14f;
            player.jumpForce = 12f;
        }


        if (currentClass.stealth == 1)
        {
            SkeletonFS.sightRange = 7;
            SkeletonMage.sightRange = 6;
            SkeletonTank.sightRange = 5;
        }
        else if(currentClass.stealth == 2)
        {
            SkeletonFS.sightRange = 5;
            SkeletonMage.sightRange = 5;
            SkeletonTank.sightRange = 4;
        }
        else if (currentClass.stealth == 3)
        {
            SkeletonFS.sightRange = 3;
            SkeletonMage.sightRange = 3;
            SkeletonTank.sightRange = 3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTripleSwipe += Time.deltaTime;
        timeSincePrimary += Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) { direction = Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { direction = Vector2.left; }
        if (Input.GetKey(KeyCode.S)) { direction = Vector2.down; }
        if (Input.GetKey(KeyCode.D)) { direction = Vector2.right; }
        // primary mouse button, 
        if (Input.GetMouseButtonDown(0) && (timeSincePrimary > 1))
        {
            KnightAttack();
            timeSincePrimary = 0;
        }
        
        ChangeCooldown();


        if ((Input.GetKeyDown(KeyCode.E)) && (Time.time > cooldownTime1) && (currentMana >= equippedSkill1.cost))
        {
            if (currentClass.name == "Wizard")
            {
                GetComponent<Animator>().SetTrigger("Skill Use");
            }
            if (start)
            {
                StopCoroutine(AssassinCriticalStrike());
                StartCoroutine(StopACS(start));
                start = false;
            }
            cooldownTime1 = Time.time + cooldown1;
            nextRecharge = Time.time + rechargeRate;
            ChangeMana(-(equippedSkill1.cost));
            equippedSkill1.Use(rb2D, direction, gameObject);
        }
        if ((Input.GetKeyDown(KeyCode.Q)) && (Time.time > cooldownTime2) && (currentMana >= equippedSkill2.cost))
        {
            if (currentClass.name == "Wizard")
            {
                GetComponent<Animator>().SetTrigger("Skill Use");
            }

            if (start)
            {
                StopCoroutine(AssassinCriticalStrike());
                StartCoroutine(StopACS(start));
                start = false;
            }
            
            cooldownTime2 = Time.time + cooldown2;
            nextRecharge = Time.time + rechargeRate;
            ChangeMana(-(equippedSkill2.cost));
            equippedSkill2.Use(rb2D, direction, gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeSkills();
        }

        if (currentMana < maxMana && Time.time > nextRecharge)
        {
            ChangeMana(0.5f);
            nextRecharge = Time.time + rechargeRate;
        }


    }

    void KnightAttack()
    {
        // Play attack animation
        animator.SetTrigger("PrimaryAttack");
        // Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, attackRange, enemyLayer);   //changed it from meleeTransformR to currentMelee so you can attack from the left
                                                                                                                // Apply damage
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)                   //make sure your not hitting the enemies from far away. without this you can hit their sight box collider
            {
                Debug.Log("We hit " + enemy.name);
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(attackDamage);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(attackDamage);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(attackDamage);
                }
            }
        }
    }

    public void ChangeMana(float amount)
    {
        currentMana = Mathf.Clamp(currentMana + amount, 0f, maxMana);
        UIBar.mana.SetValue(currentMana / (float)maxMana);
    }


    void ChangeCooldown()
    {
        float temp1 = Mathf.Clamp(cooldownTime1 - Time.time, 0f, cooldown1);
        float temp2 = Mathf.Clamp(cooldownTime2 - Time.time, 0f, cooldown2);
        SkillUI.skill1.SetValue(temp1 / cooldown1);
        SkillUI.skill2.SetValue(temp2 / cooldown2);
    }



    public void ChangeSkills()
    {
        skill1Portrait.sprite = equippedSkill1.portrait;
        skill2Portrait.sprite = equippedSkill2.portrait;


        cooldown1 = equippedSkill1.cooldown;
        cooldown2 = equippedSkill2.cooldown;

        cooldownTime1 = 0;
        cooldownTime2 = 0;
    }


    public IEnumerator WizardFlamethrower()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
        if (player.xDirection == 1)
        {
            meleeRange = 1.5f;
            player.particleR.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().TakeDamage(50);
                    }
                }
            }
            yield return new WaitForSeconds(1.25f);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies2)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().TakeDamage(50);
                    }
                }
            }
            player.particleR.GetComponent<SpriteRenderer>().enabled = false;
        }

        else
        {
            meleeRange = 1.5f;
            player.particleL.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().TakeDamage(50);
                    }
                }
            }
            yield return new WaitForSeconds(1.25f);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies2)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().TakeDamage(50);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().TakeDamage(50);
                    }
                }
            }
            player.particleL.GetComponent<SpriteRenderer>().enabled = false;
        }

        meleeRange = 0.5f;
    }



    public IEnumerator WizardFreezingBreath()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
        if (player.xDirection == 1)
        {
            meleeRange = 1.5f;
            player.particleR.GetComponent<SpriteRenderer>().color = new Color(0, 0.2f, 1, 1);
            player.particleR.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(40);
                    }
                }
            }
            yield return new WaitForSeconds(1.25f);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies2)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(40);
                    }
                }
            }
            player.particleR.GetComponent<SpriteRenderer>().enabled = false;
            player.particleR.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        else
        {
            meleeRange = 1.5f;
            player.particleL.GetComponent<SpriteRenderer>().color = new Color(0, 0.2f, 1, 1);
            player.particleL.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(40);
                    }
                }
            }
            yield return new WaitForSeconds(1.25f);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies2)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(40);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(2f, 1.15f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(40);
                    }
                }
            }
            player.particleL.GetComponent<SpriteRenderer>().enabled = false;
            player.particleR.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        meleeRange = 0.5f;
    }


    public IEnumerator WizardFreezingLand()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
        if (player.xDirection == 1)
        {
            meleeRange = 2.5f;
            player.particleR.GetComponent<SpriteRenderer>().color = new Color(0, 0.2f, 1, 1);
            player.particleR.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(57);
                    }
                }
            }
            yield return new WaitForSeconds(1.25f);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies2)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(57);
                    }
                }
            }
            player.particleR.GetComponent<SpriteRenderer>().enabled = false;
            player.particleR.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        else
        {
            meleeRange = 2.5f;
            player.particleL.GetComponent<SpriteRenderer>().color = new Color(0, 0.2f, 1, 1);
            player.particleL.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(57);
                    }
                }
            }
            yield return new WaitForSeconds(1.25f);
            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies2)
            {
                if (!enemy.isTrigger)
                {
                    if (enemy.tag == "skeletonfs")
                    {
                        enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonFS>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletonmage")
                    {
                        enemy.GetComponent<SkeletonMage>().StartCoroutine(enemy.GetComponent<SkeletonMage>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonMage>().TakeDamage(57);
                    }
                    if (enemy.tag == "skeletontank")
                    {
                        enemy.GetComponent<SkeletonTank>().StartCoroutine(enemy.GetComponent<SkeletonTank>().Freeze(4f, 1.25f));
                        enemy.GetComponent<SkeletonTank>().TakeDamage(57);
                    }
                }
            }
            player.particleL.GetComponent<SpriteRenderer>().enabled = false;
            player.particleR.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

        meleeRange = 0.5f;
    }


    public void KnightTripleSwipe()
    {
        tripleSwipeNumber++;
        if(tripleSwipeNumber>3)
        {
            tripleSwipeNumber = 1;
        }
        if(timeSinceTripleSwipe > 1.0f)
        {
            tripleSwipeNumber = 1;
        }

        GetComponent<PlayerMovement>().animator.SetTrigger("Attack" + tripleSwipeNumber);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(50 * tripleSwipeNumber);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(50 * tripleSwipeNumber);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(50 * tripleSwipeNumber);
                }
            }
        }
        timeSinceTripleSwipe = 0.0f;
    }

    


    public IEnumerator KnightBlock()
    {
        GetComponent<PlayerMovement>().animator.SetTrigger("Block");
        GetComponent<PlayerMovement>().animator.SetBool("IdleBlock", true);
        GetComponent<PlayerMovement>().evadeChance = 100;
        yield return new WaitForSeconds(1.5f);
        GetComponent<PlayerMovement>().evadeChance = 0;
        GetComponent<PlayerMovement>().animator.SetBool("IdleBlock", false);
    }

    public IEnumerator KnightParry()
    {
        GetComponent<PlayerMovement>().animator.SetTrigger("Block");
        GetComponent<PlayerMovement>().animator.SetBool("IdleBlock", true);
        GetComponent<PlayerMovement>().evadeChance = 100;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
        yield return new WaitForSeconds(1.5f);
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
        GetComponent<PlayerMovement>().evadeChance = 0;
        GetComponent<PlayerMovement>().animator.SetBool("IdleBlock", false);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(50);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(50);
                }
            }
        }
        foreach (Collider2D enemy in hitEnemies2)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(50);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(50);
                }
            }
        }
        GetComponent<PlayerMovement>().animator.SetTrigger("Attack" + 1);
    }


    public IEnumerator AssassinCounter()
    {
        GetComponent<PlayerMovement>().evadeChance = 50;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetTrigger("PrimaryAttack");
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
        GetComponent<PlayerMovement>().evadeChance = 0;
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(25);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(25);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(25);
                }
            }
        }
        foreach (Collider2D enemy in hitEnemies2)
        {
            if (!enemy.isTrigger)
            {
                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(25);
                }
                if (enemy.tag == "skeletonmage")
                {
                    enemy.GetComponent<SkeletonMage>().TakeDamage(25);
                }
                if (enemy.tag == "skeletontank")
                {
                    enemy.GetComponent<SkeletonTank>().TakeDamage(25);
                }
            }
        }
    }


    public IEnumerator AssassinInvis()
    {
        cooldownTime1 = 1000f;
        cooldownTime2 = 1000f;
        SkeletonFS.playerInvis = true;
        SkeletonMage.playerInvis = true;
        SkeletonTank.playerInvis = true;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(15);
        cooldownTime1 = 0;
        cooldownTime2 = 0;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        SkeletonFS.playerInvis = false;
        SkeletonMage.playerInvis = false;
        SkeletonTank.playerInvis = false;
    }

    public IEnumerator AssassinCriticalStrike()
    {
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        SkeletonFS.playerInvis = true;
        SkeletonMage.playerInvis = true;
        SkeletonTank.playerInvis = true;

        SkeletonFS.staticMultiplier += 1;
        SkeletonMage.staticMultiplier += 1;
        SkeletonTank.staticMultiplier += 1;

        start = true;
        yield return new WaitForSeconds(15);
        start = false;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        SkeletonFS.playerInvis = false;
        SkeletonMage.playerInvis = false;
        SkeletonTank.playerInvis = false;

        SkeletonFS.staticMultiplier -= 1;
        SkeletonMage.staticMultiplier -= 1;
        SkeletonTank.staticMultiplier -= 1;
    }
    public IEnumerator StopACS(bool runCode)
    {
        if (runCode)
        {
            playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            SkeletonFS.playerInvis = false;
            SkeletonMage.playerInvis = false;
            SkeletonTank.playerInvis = false;
            yield return new WaitForSeconds(2f);
            SkeletonFS.staticMultiplier -= 1;
            SkeletonMage.staticMultiplier -= 1;
            SkeletonTank.staticMultiplier -= 1;
        }
    }


    public IEnumerator AssassinSuperStealth()
    {
        SkeletonFS.playerInvis = true;
        SkeletonMage.playerInvis = true;
        SkeletonTank.playerInvis = true;
        yield return new WaitForSeconds(5f);
        SkeletonFS.playerInvis = false;
        SkeletonMage.playerInvis = false;
        SkeletonTank.playerInvis = false;
    }



    public IEnumerator RangerArrowFlurry(GameObject prefab)
    {
        float rotation = 0;
        if (direction == Vector2.left) { rotation = 180; }
        if (direction == Vector2.up) { rotation = 90; }
        if (direction == Vector2.down) { rotation = 270; }

        GameObject Arrow1 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile1 = Arrow1.GetComponent<attack>();
        projectile1.damage = 10f;
        projectile1.life = 1f;
        projectile1.speed = 1000;
        projectile1.Launch(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Arrow2 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile2 = Arrow2.GetComponent<attack>();
        projectile2.damage = 10f;
        projectile2.life = 1f;
        projectile2.speed = 1000;
        projectile2.Launch(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Arrow3 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile3 = Arrow3.GetComponent<attack>();
        projectile3.damage = 10f;
        projectile3.life = 1f;
        projectile3.speed = 1000;
        projectile3.Launch(direction);
    }

    public IEnumerator RangerSpearFlurry(GameObject prefab)
    {
        float rotation = 0;
        if (direction == Vector2.left) { rotation = 180; }
        if (direction == Vector2.up) { rotation = 90; }
        if (direction == Vector2.down) { rotation = 270; }

        GameObject Spear1 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile1 = Spear1.GetComponent<attack>();
        projectile1.damage = 20f;
        projectile1.life = 5;
        projectile1.speed = 1600;
        projectile1.Throw(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Spear2 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile2 = Spear2.GetComponent<attack>();
        projectile2.damage = 20f;
        projectile2.life = 5;
        projectile2.speed = 1600;
        projectile2.Throw(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Spear3 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile3 = Spear3.GetComponent<attack>();
        projectile3.damage = 20f;
        projectile3.life = 5;
        projectile3.speed = 1600;
        projectile3.Throw(direction);
    }


    public IEnumerator RangerHeavansFlurry(GameObject prefab)
    {
        float rotation = 270;
        Vector2 off = new Vector2(8, 6f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-8, 6f);
        }

        GameObject Arrow1 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile1 = Arrow1.GetComponent<attack>();
        projectile1.damage = 10f;
        projectile1.life = 1000f;
        projectile1.speed = 500;
        projectile1.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow2 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile2 = Arrow2.GetComponent<attack>();
        projectile2.damage = 10f;
        projectile2.life = 1000f;
        projectile2.speed = 500;
        projectile2.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow3 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile3 = Arrow3.GetComponent<attack>();
        projectile3.damage = 10.5f;
        projectile3.life = 1000f;
        projectile3.speed = 500;
        projectile3.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow4 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile4 = Arrow4.GetComponent<attack>();
        projectile4.damage = 10.5f;
        projectile4.life = 1000f;
        projectile4.speed = 500;
        projectile4.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow5 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile5 = Arrow5.GetComponent<attack>();
        projectile5.damage = 10.5f;
        projectile5.life = 1000f;
        projectile5.speed = 500;
        projectile5.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow6 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile6 = Arrow6.GetComponent<attack>();
        projectile6.damage = 10.5f;
        projectile6.life = 1000f;
        projectile6.speed = 500;
        projectile6.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow7 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile7 = Arrow7.GetComponent<attack>();
        projectile7.damage = 10.5f;
        projectile7.life = 1000f;
        projectile7.speed = 500;
        projectile7.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow8 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile8 = Arrow8.GetComponent<attack>();
        projectile8.damage =10.5f;
        projectile8.life = 1000f;
        projectile8.speed = 500;
        projectile8.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow9 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile9 = Arrow9.GetComponent<attack>();
        projectile9.damage = 10.5f;
        projectile9.life = 1000f;
        projectile9.speed = 500;
        projectile9.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow10 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.Euler(new Vector3(0, 0, rotation)));
        attack projectile10 = Arrow10.GetComponent<attack>();
        projectile10.damage = 10.5f;
        projectile10.life = 1000f;
        projectile10.speed = 500;
        projectile10.Launch(Vector2.down);
    }


    public IEnumerator RangerCharge()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
        bool wasSaddled = true;
        if (player.jumpForce == 10f)
        {
            player.transform.localScale = new Vector3(12, 15, 1);
            player.groundChecker.localPosition += new Vector3(0, -0.025f, 0);
            wasSaddled = false;
        }

        Vector2 tempDirection = direction;
        if(tempDirection == Vector2.up || tempDirection == Vector2.down) { tempDirection = Vector2.right; }
        for(int i = 0; i <= 5; i++)
        {
            rb2D.velocity = tempDirection * 50;
            yield return new WaitForSeconds(0.03f);
        }
        rb2D.velocity = Vector2.zero;

        if (!wasSaddled)
        {
            player.transform.localScale = new Vector3(10, 10, 1);
            player.groundChecker.localPosition += new Vector3(0, 0.025f, 0);
        }
    }

    public IEnumerator RangerFlameCharge()
    {
        GetComponent<PlayerMovement>().evadeChance = 100;
        PlayerMovement player = GetComponent<PlayerMovement>();
        bool wasSaddled = true;
        if (player.jumpForce == 10f)
        {
            player.transform.localScale = new Vector3(12, 15, 1);
            player.groundChecker.localPosition += new Vector3(0, -0.025f, 0);
            wasSaddled = false;
        }

        Vector2 tempDirection = direction;
        if (tempDirection == Vector2.up || tempDirection == Vector2.down) { tempDirection = Vector2.right; }
        for (int i = 0; i <= 10; i++)
        {
            rb2D.velocity = tempDirection * 50;
            yield return new WaitForSeconds(0.03f);
        }
        rb2D.velocity = Vector2.zero;
        GetComponent<PlayerMovement>().evadeChance = 0;

        if (!wasSaddled)
        {
            player.transform.localScale = new Vector3(10, 10, 1);
            player.groundChecker.localPosition += new Vector3(0, 0.025f, 0);
        }
    }


    public IEnumerator RangerMountsProtection()
    {
        GetComponent<PlayerMovement>().evadeChance = 100;
        PlayerMovement player = GetComponent<PlayerMovement>();
        bool wasSaddled = true;
        if (player.jumpForce == 10f)
        {
            player.speed += 7f;
            player.jumpForce -= 1.5f;
            player.fallMultiplier += 1.5f;
            player.transform.localScale = new Vector3(12, 15, 1);
            player.groundChecker.localPosition += new Vector3(0, -0.025f, 0);
            wasSaddled = false;
        }

        yield return new WaitForSeconds(15f);

        if(!wasSaddled)
        {
            player.speed -= 7f;
            player.jumpForce += 1.5f;
            player.fallMultiplier -= 1.5f;
            player.transform.localScale = new Vector3(10, 10, 1);
            player.groundChecker.localPosition += new Vector3(0, 0.025f, 0);
        }
        GetComponent<PlayerMovement>().evadeChance = 0;
    }





    private void OnDrawGizmosSelected()
    {
        if (meleeTransformR == null) { return; }
        Gizmos.DrawWireSphere(meleeTransformR.position, meleeRange);
        if (meleeTransformL == null) { return; }
        Gizmos.DrawWireSphere(meleeTransformL.position, meleeRange);
    }
}
