using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleFire : MonoBehaviour
{
    public float speed = 3;
    public Rigidbody2D rb;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health player = collision.GetComponent<Health>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
