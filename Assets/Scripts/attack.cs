using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float life = 6;
    public float damage;
    public float speed;
    public bool hitsEnemies = true;
    public float cooldown;
    public int cost;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        StartCoroutine(wait(life));
    }

    public void Launch(Vector2 direction)
    {
        rigidbody2d.AddForce(direction * speed);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }

    IEnumerator wait(float life)
    {
        //Debug.Log(life);
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
