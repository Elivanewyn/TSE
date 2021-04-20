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
            StartCoroutine(SpeedBoost());
        }
        if(Input.GetKey(KeyCode.Q) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            HealthRenewal();
        }
    }




    void Fireball()
    {
        GameObject Fireball = Instantiate(skill1, rb2D.position + direction * 3f, Quaternion.identity);

        attack projectile = Fireball.GetComponent<attack>();
        projectile.damage = 1;
        projectile.life = 0.5f;
        projectile.speed = 800;
        projectile.Launch(direction);
    }

    void FireBlast()
    {
        GameObject Fireblast = Instantiate(skill2, rb2D.position + direction * 3f, Quaternion.identity);

        attack projectile = Fireblast.GetComponent<attack>();
        projectile.damage = 2;
        projectile.life = 3.0f;
        projectile.speed = 650;
        projectile.Launch(direction);
    }

    void Flamethrower()
    {
        //will wait for level to be populated to test easier
    }


    void Flameburst()
    {
        GameObject Flameburst = Instantiate(skill1, rb2D.position + direction * 3f, Quaternion.identity);

        attack projectile = Flameburst.GetComponent<attack>();
        projectile.damage = 3;
        projectile.life = 6.0f;
        projectile.speed = 500;
        projectile.Launch(direction);
    }

    void FireTornado()
    {
        GameObject FireTornado = Instantiate(skill2, rb2D.position + direction * 3f, Quaternion.identity);

        attack projectile = FireTornado.GetComponent<attack>();
        projectile.damage = 4;
        projectile.life = 1000f;
        projectile.speed = 750;
        projectile.hitsEnemies = false;
        projectile.Launch(direction);
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
        strike.life = 0.5f;
    }

    void LightningBolt()
    {
        Vector2 off = new Vector2(5, 1f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-5, 1f);
        }

        GameObject LightningBolt = Instantiate(skill1, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack strike = LightningBolt.GetComponent<attack>();
        strike.damage = 3;
        strike.life = 0.5f;
    }

    void ElectricCage()
    {
        //will wait for level to be populated
    }

    void PlasmaCharge()
    {
        Vector2 off = new Vector2(5, 2.7f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-5, 2.7f);
        }

        GameObject PlasmaCharge = Instantiate(skill2, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack strike = PlasmaCharge.GetComponent<attack>();
        strike.damage = 3;
        strike.life = 0.8f;
    }

    void LightningPillar()
    {
        Vector2 off = new Vector2(5, 0.2f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-5, 0.2f);
        }

        GameObject LightningPillar = Instantiate(skill1, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack strike = LightningPillar.GetComponent<attack>();
        strike.damage = 0.1f;
        strike.life = 150f;
        strike.hitsEnemies = false;
    }



    void FrostWave()
    {
        if((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

        Vector2 off = new Vector2(8, -1.3f);
        if (direction == Vector2.left)
        {
            off = new Vector2(-8, -1.3f);
        }

        GameObject FrostWave = Instantiate(skill2, rb2D.position + off + direction * 3f, Quaternion.identity);
        attack fwave = FrostWave.GetComponent<attack>();
        fwave.damage = 1;
        fwave.life = 6.0f;
    }


    void IcePillar()
    {
        //will wait for level to be populated
    }

    void FreezingBreath()
    {
        //will wait for level to be populated
    }

    void IceCrash()
    {
        if ((direction == Vector2.up) || (direction == Vector2.down)) { direction = Vector2.right; }

        

        GameObject IceCrash = Instantiate(skill1, rb2D.position + direction * 3f, Quaternion.identity);
        attack fwave = IceCrash.GetComponent<attack>();
        fwave.damage = 3.5f;
        fwave.life = 5.0f;
        fwave.speed = 1000f;
        fwave.Launch(direction);
    }

    void FreezingLand()
    {
        //will wait for level to be populated
    }


    void HealingChime()
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        player.ChangeHealth(1);
    }

    IEnumerator SpeedBoost()
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        player.speed += 3;
        yield return new WaitForSeconds(5);
        player.speed -= 3;
    }

    IEnumerable EvasionAmplification()
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        player.evadeChance += 10;
        yield return new WaitForSeconds(15);
        player.evadeChance -= 10;
    }

    void DefenceBoost()
    {
        //will wait for stats stuff
    }

    void HealthRenewal()
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        player.ChangeHealth(3);
    }

}
