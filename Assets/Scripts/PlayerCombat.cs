using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static ClassSystem.PlayerClass currentClass;
    private ClassSystem.Skill equippedSkill1;
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
        currentMana = maxMana;
        currentClass = ClassSystem.assassin;


        equippedSkill1 = currentClass.skillTreeThree[3];
        equippedSkill2 = currentClass.skillTreeThree[4];


        cooldown1 = equippedSkill1.cooldown;
        cooldown2 = equippedSkill2.cooldown;

        cooldownTime1 = 0;
        cooldownTime2 = 0;
        nextRecharge = rechargeRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) { direction = Vector2.up; }
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
        if((Input.GetKey(KeyCode.Q)) && (Time.time > cooldownTime2) && (currentMana >= equippedSkill2.cost))
        {
            cooldownTime2 = Time.time + cooldown2;
            nextRecharge = Time.time + rechargeRate;
            ChangeMana(-(equippedSkill2.cooldown));
            equippedSkill2.Use(rb2D, direction, gameObject);
        }

        if(currentMana < maxMana && Time.time > nextRecharge)
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
}
