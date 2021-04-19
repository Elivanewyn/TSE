using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float life = 6;
    public float damage;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        StartCoroutine(wait(life));
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    void Update()
    {

    }

    IEnumerator wait(float life)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
