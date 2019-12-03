using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBoss : MonoBehaviour
{
    public float timer = 5f;
    Rigidbody2D rb;
    int jump = 2;
    int two = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Health health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (jump % two == 0)
            {
                rb.velocity = new Vector2(5, 10);
                timer = 5f;
                jump++;
            }
            else
            {
                rb.velocity = new Vector2(-5, 10);
                timer = 5f;
                jump++;
            }
        }
    }
}
