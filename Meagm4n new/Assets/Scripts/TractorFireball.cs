using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorFireball : MonoBehaviour
{
    public float speed = -5;
    public Rigidbody2D rb;
    public Transform direction;
    public int damage;
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        gameObject.transform.Rotate(0, 0, 30);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health player = collision.GetComponent<Health>();

        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
    }
}
