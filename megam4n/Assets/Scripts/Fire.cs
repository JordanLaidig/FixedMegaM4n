using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();

        if (!collision.CompareTag("Player"))
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
    }
}
