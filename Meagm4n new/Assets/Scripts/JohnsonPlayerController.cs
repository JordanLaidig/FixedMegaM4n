﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnsonPlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;
    Health health;
    JohnsonBar bar;
    Transform direction;
    private int kb;

    private bool hasJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        direction = GetComponent<Transform>();
        kb = 0;
    }
    public void knockback()
    {
        kb = 40;
    }
    private void Update()
    {
        if (kb > 0)
            kb--;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (kb == 0)
        {
            if (Input.GetKey("h"))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rb.velocity = new Vector2((onGround() ? 6 : rb.velocity.x + (rb.velocity.x < 6 ? 0.5F : 0)), rb.velocity.y);
            }
            else if (Input.GetKey("f"))
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                rb.velocity = new Vector2((onGround() ? -6 : rb.velocity.x + (rb.velocity.x > -6 ? -0.5F : 0)), rb.velocity.y);
            }


            if (Input.GetKey("t") && (onGround() || !hasJumped))
            {
                rb.velocity = new Vector2(rb.velocity.x, 19);
                hasJumped = true;
            }
            else if (Input.GetKey("t") && onWall() && direction.rotation.y == 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                rb.velocity = new Vector2(-6, 20);
            }
            else if (Input.GetKey("t") && onWall() && direction.rotation.y != 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rb.velocity = new Vector2(6, 20);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  //Player hit a ground tagged object
            hasJumped = false;
    }

    private bool onGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, 1, LayerMask.GetMask("Ground"));   
        return hit.collider != null ? true : false;
    }

    private bool onWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, (direction.rotation.y == 0 ? Vector2.right : Vector2.left), 1.5F, LayerMask.GetMask("Ground"));  
        return hit.collider != null ? true : false;
    }
}

