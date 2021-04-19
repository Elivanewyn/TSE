using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public GameObject skill1;
    public GameObject skill2;
    public float fireRate = 1.0f;
    private float nextFire;
    Rigidbody2D rb2D;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
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
            Fireball();
        }
        if(Input.GetKey(KeyCode.Q) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            LightningStrike();
        }
    }

    void Fireball()
    {
        GameObject Fireball = Instantiate(skill1, rb2D.position + direction * 3f, Quaternion.identity);

        attack projectile = Fireball.GetComponent<attack>();
        projectile.damage = 1;
        projectile.Launch(direction, 800);
    }

    void LightningStrike()
    {
        Vector2 off = new Vector2(5, -0.6f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-5, -0.6f);
        }

        
        GameObject LightningStrike = Instantiate(skill2, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack strike = LightningStrike.GetComponent<attack>();
        strike.damage = 2;
    }
}
