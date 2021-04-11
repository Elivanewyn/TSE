using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject playerAttack;
    public float fireRate = 1.0f;
    private float nextFire;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Launch1();
        }
    }

    void Launch1()
    {
        GameObject attack = Instantiate(playerAttack, rb2D.position + Vector2.right * 3f, Quaternion.identity);

        attack projectile = attack.GetComponent<attack>();
        projectile.Launch(Vector2.right, 1000);

    }
}
