using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorgePlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;
    JorgeBar bar;
    Health health;
    Transform direction;
    GameManager game;

    bool grounded = true;
    bool onWall = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        direction = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(6, rb.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector2(-6, rb.velocity.y);
        }


        if(Input.GetKey("w") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 20);
            grounded = false;
            onWall = false;
        }
        else if(Input.GetKey("w") && onWall && direction.rotation.y == 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector2(-6, 20);
            onWall = false;
        }
        else if(Input.GetKey("w") && onWall && direction.rotation.y != 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(6, 20);
            onWall = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            onWall = false;
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            onWall = true;
            grounded = false;

        }
    }
}
