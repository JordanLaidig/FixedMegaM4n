using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSeekerController : MonoBehaviour
{
    public float speed;
    public Transform playerDetector;
    public Sprite explosion;
    public float timer = 2f;
    public bool death = false;


    // Start is called before the first frame update
    void Start()
    {
        Health health = GetComponent<Health>();
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
        if (death)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            explode();
        }
    }

    void explode()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = explosion;
        var collisions = Physics2D.CircleCastAll(gameObject.transform.position, 2.5f , Vector2.zero);
        foreach (var c in collisions)
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
        death = true;
    }
    
    

}
