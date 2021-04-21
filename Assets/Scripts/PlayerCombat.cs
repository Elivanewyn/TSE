using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static ClassSystem.PlayerClass currentClass;
    public ClassSystem.Skill equippedSkill1;
    public ClassSystem.Skill equippedSkill2;

    public float fireRate = 1.0f;
    private float nextFire;

    public float maxMana = 20;
    public float mana { get { return currentMana; } }
    float currentMana;

    Rigidbody2D rb2D;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        currentMana = maxMana;
        currentClass = ClassSystem.wizard;

        equippedSkill1 = currentClass.basicSkills[0];
        equippedSkill2 = currentClass.basicSkills[1];

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) { direction = Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { direction = Vector2.left; }
        if (Input.GetKey(KeyCode.S)) { direction = Vector2.down; }
        if (Input.GetKey(KeyCode.D)) { direction = Vector2.right; }



        if (Input.GetKey(KeyCode.E) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            equippedSkill1.Use(rb2D, direction, gameObject);
        }
        if(Input.GetKey(KeyCode.Q) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            equippedSkill2.Use(rb2D, direction, gameObject);
        }

        if(currentMana < maxMana && Time.time > nextFire)
        {
            ChangeMana(0.5f);
            nextFire = Time.time + fireRate;
        }
    }

    public void ChangeMana(float amount)
    {
        currentMana = Mathf.Clamp(currentMana + amount, 0f, maxMana);
        Debug.Log(currentMana);
        //UIBar.instance.SetValue(currentMana / (float)maxMana);
    }

}
