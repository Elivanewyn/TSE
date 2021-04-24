﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static ClassSystem.PlayerClass currentClass;
    public ClassSystem.Skill equippedSkill1;
    public ClassSystem.Skill equippedSkill2;

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

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        currentClass = ClassSystem.ranger;


        equippedSkill1 = currentClass.skillTreeOne[1];
        equippedSkill2 = currentClass.basicSkills[3];


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
        if (Input.GetKey(KeyCode.W)) { direction = Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { direction = Vector2.left; }
        if (Input.GetKey(KeyCode.S)) { direction = Vector2.down; }
        if (Input.GetKey(KeyCode.D)) { direction = Vector2.right; }



        if ((Input.GetKey(KeyCode.E)) && (Time.time > cooldownTime1) && (currentMana >= equippedSkill1.cost))
        {
            cooldownTime1 = Time.time + cooldown1;
            nextRecharge = Time.time + rechargeRate;
            ChangeMana(-(equippedSkill1.cost));
            equippedSkill1.Use(rb2D, direction, gameObject);
        }
        if ((Input.GetKey(KeyCode.Q)) && (Time.time > cooldownTime2) && (currentMana >= equippedSkill2.cost))
        {
            cooldownTime2 = Time.time + cooldown2;
            nextRecharge = Time.time + rechargeRate;
            ChangeMana(-(equippedSkill2.cooldown));
            equippedSkill2.Use(rb2D, direction, gameObject);
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
        cooldownTime1 = 1000f;
        cooldownTime2 = 1000f;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(15);
        cooldownTime1 = 0;
        cooldownTime2 = 0;
        playerSprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
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
}
