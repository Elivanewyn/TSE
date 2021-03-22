using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2D;

    public float speed = 7.0f;
    Vector2 lookDirect = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirect.Set(move.x, move.y);
            lookDirect.Normalize();
        }
        Vector2 position = rb2D.position;

        position = position + move * speed * Time.deltaTime;
        rb2D.MovePosition(position);
    }
}
