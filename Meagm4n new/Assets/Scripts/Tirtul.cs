using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirtul : MonoBehaviour
{
    public int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
