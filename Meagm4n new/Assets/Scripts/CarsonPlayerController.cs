using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsonPlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;
    Health health;
    Transform direction;

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

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey("l"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(6, rb.velocity.y);
        }
        else if (Input.GetKey("j"))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector2(-6, rb.velocity.y);
        }


        if (Input.GetKey("i") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 20);
            grounded = false;
        }
        else if (Input.GetKey("i") && onWall && direction.rotation.y == 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            rb.velocity = new Vector2(-6, 20);
            onWall = false;
        }
        else if (Input.GetKey("i") && onWall && direction.rotation.y != 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(6, 20);
            onWall = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  //Player hit a ground tagged object
        {
            //Cast ray down from player position a distance of 1, look only for tags in mask
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, 1, LayerMask.GetMask("Ground"));   
            if(true/*hit.collider != null*/)    //Player hit ground tagged object, and ground is below therefore Player is on ground
            {
                grounded = true;
                onWall = false;
            }  
            else                        //Player hit ground tagged object, and no ground is below therefore Player is on wall
            {
                grounded = false;
                onWall = true;
            }
                /*Debug Draw Ray*/
            //Vector3 down = transform.TransformDirection(Vector3.down) * 1;
            //Debug.DrawRay(rb.position, down, Color.green, 10, false);
        }
    }
}
