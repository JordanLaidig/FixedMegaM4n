using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JousterAi : MonoBehaviour
{
    //target is supposed to be the first player to enter a certain range of the Jouster, and the Jouster is supposed to find a path towards the target
    public Transform target;
    public int speed = 2;
    public Rigidbody2D rb;
    public Transform groundDetection;
    private float xOriginal;
    private float yOriginal;
    public RaycastHit2D groundInfo;
    public float thrust;
    private GameObject jouster;

    // Start is called before the first frame update
    void Start()
    {
        xOriginal = transform.position.x;
        jouster = this.gameObject;
        thrust = 300;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(20);
                if (health == null)
                    FindNewTarget();
                else
                {

                    var knockBackDirection = collision.gameObject.GetComponent<Transform>().position;
                    rb = collision.gameObject.GetComponent<Rigidbody2D>();

                    if ((collision.gameObject.transform.position.x < transform.position.x && collision.gameObject.transform.eulerAngles.y == 0) || (collision.gameObject.transform.position.x > transform.position.x && collision.gameObject.transform.eulerAngles.y == -180))
                    {
                        rb.AddForce(-collision.gameObject.transform.right * thrust);
                        rb.AddForce(collision.gameObject.transform.up * thrust);
                    }
                    else
                    {
                        rb.AddForce(collision.gameObject.transform.right * thrust);
                        rb.AddForce(collision.gameObject.transform.up * thrust);
                    }
                    JorgePlayerController jorge = gameObject.GetComponent<JorgePlayerController>();
                    CarsonPlayerController carson = gameObject.GetComponent<CarsonPlayerController>();
                    JoePlayerController joe = gameObject.GetComponent<JoePlayerController>();
                    JohnsonPlayerController johnson = gameObject.GetComponent<JohnsonPlayerController>();
                    if (jorge != null)
                        jorge.knockback();
                    if (carson != null)
                        carson.knockback();
                    if (joe != null)
                        joe.knockback();
                    if (johnson != null)
                        johnson.knockback();
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (target != null)
        {
            if (groundInfo.collider)
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            else
                transform.Translate(Vector2.left * 0);
            if (transform.position.x > target.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
        else
        {
            if (System.Math.Abs(xOriginal - transform.position.x) < 0.25f)
            {
                transform.Translate(Vector2.left * 0);
            }
            else if (transform.position.x < xOriginal)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else if (transform.position.x > xOriginal)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    public GameObject getOriginalJouster()
    {
        return jouster;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && target == null)
        {
            target = collision.gameObject.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.Equals(target))
        {
            target = null;
            FindNewTarget();
        }
    }
    private void FindNewTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Player"))
            {
                if (target == null)
                {
                    target = colliders[i].transform;
                }
                else
                {
                    if (System.Math.Sqrt((colliders[i].transform.position.x - transform.position.x) * (colliders[i].transform.position.x - transform.position.x) + (colliders[i].transform.position.y - transform.position.y) * (colliders[i].transform.position.y - transform.position.y)) < System.Math.Sqrt((target.position.x - transform.position.x) * (target.position.x - transform.position.x) + (target.position.y - transform.position.y) * (target.position.y - transform.position.y)))
                    {
                        target = colliders[i].transform;
                    }
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
