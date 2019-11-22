using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSeekerController : MonoBehaviour
{
    public float speed;
    public Transform playerDetector;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D detectorInfo = Physics2D.Raycast(playerDetector.position, Vector2.down);
        if(detectorInfo.transform.tag == "Player")
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(20);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            explode();
        }

    }

    void explode()
    {
        var collisions = Physics2D.CircleCastAll(gameObject.transform.position, 5, transform.position);
        foreach(var c in collisions)
        {
            if (c.collider.gameObject.CompareTag("Player"))
            {
                Health health = c.collider.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(20);
                }
            }
        }
        Destroy(gameObject);
    }

}
