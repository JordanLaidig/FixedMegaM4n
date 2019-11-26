using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossController : MonoBehaviour
{
    public int health = 300;
    public int threshold = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
