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

    Vector2 direction;

    public SpriteRenderer playerSprite;
    public Transform meleeTransformR;
    public Transform meleeTransformL;
    public Transform currentMelee;
    public float meleeRange = 0.5f;
    public LayerMask enemyLayer;


    private int tripleSwipeNumber = 0;
    private float timeSinceTripleSwipe = 0.0f;


    bool start = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;


        equippedSkill1 = currentClass.basicSkills[0];
        equippedSkill2 = currentClass.basicSkills[1];

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

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTripleSwipe += Time.deltaTime;


        if (Input.GetKey(KeyCode.W)) { direction = Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { direction = Vector2.left; }
        if (Input.GetKey(KeyCode.S)) { direction = Vector2.down; }
        if (Input.GetKey(KeyCode.D)) { direction = Vector2.right; }


        ChangeCooldown();


        if ((Input.GetKeyDown(KeyCode.E)) && (Time.time > cooldownTime1) && (currentMana >= equippedSkill1.cost))
        {

            if(start)
            {
                StopCoroutine(AssassinCriticalStrike());
                StartCoroutine(StopACS());
                start = false;
            }

            cooldownTime1 = Time.time + cooldown1;
            nextRecharge = Time.time + rechargeRate;
            ChangeMana(-(equippedSkill1.cost));
            equippedSkill1.Use(rb2D, direction, gameObject);
        }
        if ((Input.GetKeyDown(KeyCode.Q)) && (Time.time > cooldownTime2) && (currentMana >= equippedSkill2.cost))
        {
            if (start)
            {
                StopCoroutine(AssassinCriticalStrike());
                StartCoroutine(StopACS());
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
            yield return new WaitForSeconds(1.25f);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                }
                if (enemy.tag == "skeletonmage")
                {
                    //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                }
                if (enemy.tag == "skeletontank")
                {
                    //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
                }
            }
            player.particleR.GetComponent<SpriteRenderer>().enabled = false;
        }

        else
        {
            meleeRange = 1.5f;
            player.particleL.GetComponent<SpriteRenderer>().enabled = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentMelee.position, meleeRange, enemyLayer);
            yield return new WaitForSeconds(1.25f);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(50);
                }
                if (enemy.tag == "skeletonmage")
                {
                    //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                }
                if (enemy.tag == "skeletontank")
                {
                    //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
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
            yield return new WaitForSeconds(1.25f);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(40);
                    enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(2f));
                }
                if (enemy.tag == "skeletonmage")
                {
                    //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                    //enemy.GetComponent<SkeletonMage>().Freeze(2f);
                }
                if (enemy.tag == "skeletontank")
                {
                    //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
                    //enemy.GetComponent<SkeletonTank>().Freeze(2f);
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
            yield return new WaitForSeconds(1.25f);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(40);
                    enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(2f));
                }
                if (enemy.tag == "skeletonmage")
                {
                    //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                }
                if (enemy.tag == "skeletontank")
                {
                    //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
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
            yield return new WaitForSeconds(1.25f);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(57);
                    enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(4f));
                }
                if (enemy.tag == "skeletonmage")
                {
                    //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                    //enemy.GetComponent<SkeletonMage>().Freeze(2f);
                }
                if (enemy.tag == "skeletontank")
                {
                    //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
                    //enemy.GetComponent<SkeletonTank>().Freeze(2f);
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
            yield return new WaitForSeconds(1.25f);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.tag == "skeletonfs")
                {
                    enemy.GetComponent<SkeletonFS>().TakeDamage(57);
                    enemy.GetComponent<SkeletonFS>().StartCoroutine(enemy.GetComponent<SkeletonFS>().Freeze(4f));
                }
                if (enemy.tag == "skeletonmage")
                {
                    //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
                }
                if (enemy.tag == "skeletontank")
                {
                    //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
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

            if (enemy.tag == "skeletonfs")
            {
                enemy.GetComponent<SkeletonFS>().TakeDamage(50 * tripleSwipeNumber);
            }
            if (enemy.tag == "skeletonmage")
            {
                //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
            }
            if (enemy.tag == "skeletontank")
            {
                //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
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
        GetComponent<PlayerMovement>().evadeChance = 0;
        GetComponent<PlayerMovement>().animator.SetBool("IdleBlock", false);
        foreach (Collider2D enemy in hitEnemies)
        {

            if (enemy.tag == "skeletonfs")
            {
                enemy.GetComponent<SkeletonFS>().TakeDamage(50);
            }
            if (enemy.tag == "skeletonmage")
            {
                //enemy.GetComponent<SkeletonMage>().TakeDamge(300);
            }
            if (enemy.tag == "skeletontank")
            {
                //enemy.GetComponent<SkeletonTank>().TakeDamage(300);
            }
        }
        GetComponent<PlayerMovement>().animator.SetTrigger("Attack" + 1);
    }




    public IEnumerator AssassinInvis()
    {
        cooldownTime1 = 1000f;
        cooldownTime2 = 1000f;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(15);
        cooldownTime1 = 0;
        cooldownTime2 = 0;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }

    public IEnumerator AssassinCriticalStrike()
    {
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        attack.damageMultiplier = 2;
        start = true;
        yield return new WaitForSeconds(15);
        start = false;
        attack.damageMultiplier = 1;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }


    public IEnumerator StopACS()
    {
        if (attack.damageMultiplier == 2)
        {
            playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            yield return new WaitForSeconds(1f);
            attack.damageMultiplier = 1;
        }
    }


    public IEnumerator RangerArrowFlurry(GameObject prefab)
    {
        GameObject Arrow1 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
        attack projectile1 = Arrow1.GetComponent<attack>();
        projectile1.damage = 0.5f;
        projectile1.life = 1f;
        projectile1.speed = 1000;
        projectile1.Launch(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Arrow2 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
        attack projectile2 = Arrow2.GetComponent<attack>();
        projectile2.damage = 0.5f;
        projectile2.life = 1f;
        projectile2.speed = 1000;
        projectile2.Launch(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Arrow3 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
        attack projectile3 = Arrow3.GetComponent<attack>();
        projectile3.damage = 0.5f;
        projectile3.life = 1f;
        projectile3.speed = 1000;
        projectile3.Launch(direction);
    }

    public IEnumerator RangerSpearFlurry(GameObject prefab)
    {
        GameObject Spear1 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
        attack projectile1 = Spear1.GetComponent<attack>();
        projectile1.damage = 3f;
        projectile1.life = 5;
        projectile1.speed = 1600;
        projectile1.Throw(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Spear2 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
        attack projectile2 = Spear2.GetComponent<attack>();
        projectile2.damage = 3f;
        projectile2.life = 5;
        projectile2.speed = 1600;
        projectile2.Throw(direction);
        yield return new WaitForSeconds(0.3f);

        GameObject Spear3 = Instantiate(prefab, rb2D.position + direction * 3f, Quaternion.identity);
        attack projectile3 = Spear3.GetComponent<attack>();
        projectile3.damage = 3f;
        projectile3.life = 5;
        projectile3.speed = 1600;
        projectile3.Throw(direction);
    }


    public IEnumerator RangerHeavansFlurry(GameObject prefab)
    {
        Vector2 off = new Vector2(8, 6f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-8, 6f);
        }

        GameObject Arrow1 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile1 = Arrow1.GetComponent<attack>();
        projectile1.damage = 0.5f;
        projectile1.life = 1000f;
        projectile1.speed = 500;
        projectile1.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow2 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile2 = Arrow2.GetComponent<attack>();
        projectile2.damage = 0.5f;
        projectile2.life = 1000f;
        projectile2.speed = 500;
        projectile2.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow3 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile3 = Arrow3.GetComponent<attack>();
        projectile3.damage = 0.5f;
        projectile3.life = 1000f;
        projectile3.speed = 500;
        projectile3.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow4 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile4 = Arrow4.GetComponent<attack>();
        projectile4.damage = 0.5f;
        projectile4.life = 1000f;
        projectile4.speed = 500;
        projectile4.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow5 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile5 = Arrow5.GetComponent<attack>();
        projectile5.damage = 0.5f;
        projectile5.life = 1000f;
        projectile5.speed = 500;
        projectile5.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow6 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile6 = Arrow6.GetComponent<attack>();
        projectile6.damage = 0.5f;
        projectile6.life = 1000f;
        projectile6.speed = 500;
        projectile6.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow7 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile7 = Arrow7.GetComponent<attack>();
        projectile7.damage = 0.5f;
        projectile7.life = 1000f;
        projectile7.speed = 500;
        projectile7.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow8 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile8 = Arrow8.GetComponent<attack>();
        projectile8.damage = 0.5f;
        projectile8.life = 1000f;
        projectile8.speed = 500;
        projectile8.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow9 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile9 = Arrow9.GetComponent<attack>();
        projectile9.damage = 0.5f;
        projectile9.life = 1000f;
        projectile9.speed = 500;
        projectile9.Launch(Vector2.down);

        yield return new WaitForSeconds(0.4f);

        GameObject Arrow10 = Instantiate(prefab, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack projectile10 = Arrow10.GetComponent<attack>();
        projectile10.damage = 0.5f;
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
            player.speed += 5f;
            player.jumpForce -= 2f;
            player.fallMultiplier += 2f;
            player.transform.localScale = new Vector3(12, 15, 1);
            player.groundChecker.localPosition += new Vector3(0, -0.025f, 0);
            wasSaddled = false;
        }

        yield return new WaitForSeconds(15f);

        if(!wasSaddled)
        {
            player.speed -= 5f;
            player.jumpForce += 2f;
            player.fallMultiplier -= 2f;
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
