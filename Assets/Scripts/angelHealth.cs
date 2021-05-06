using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelHealth : MonoBehaviour
{
    public int health = 500;

    public bool isInvulnerable = false;

    public bool enraged = false;

    public void takeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            enraged = true;
        }
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
