using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2D;

    public float speed = 7.0f;
    public float jumpForce = 6.0f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isGrounded = false;
    public Transform groundChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float rememberGrounded;
    private float lastTimeGrounded;
    public float invincibleTime = 1.0f;
    private float nextInvincible;

    public Canvas inventory;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        inventory.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckGrounded();

        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeHealth(-1);
        }
        if(Input.GetKeyDown(KeyCode.F) && (inventory.enabled))
        {
            Time.timeScale = 1f;
            inventory.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0.0f;
            
            inventory.enabled = true;
        }


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb2D.velocity = new Vector2(moveBy, rb2D.velocity.y);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGrounded))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    void CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);

        if(collider != null) { isGrounded = true; }
        else
        {
            if(isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void BetterJump()
    {
        if(rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void ChangeHealth(int amount)
    {
        Debug.Log(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "skeletonfs" && Time.time > nextInvincible)
        {
            nextInvincible = Time.time + invincibleTime;
            ChangeHealth(-2);
        }

        if (other.gameObject.tag == "skeletontank" && Time.time > nextInvincible)
        {
            nextInvincible = Time.time + invincibleTime;
            ChangeHealth(-1);
        }

        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "skeletonmage")
        {
            
            ChangeHealth(-3);
        }
    }
}
