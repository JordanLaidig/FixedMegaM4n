using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorFlameThrower : MonoBehaviour
{
    public Transform TractorFlameFirePoint;
    public GameObject TractorFireball;
    public float timer = 5f;
    public float timer2 = 4f;
    public float timer3 = .4f;
    public bool fire = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            fire = true;
        }

        if(fire)
        {
            timer2 -= Time.deltaTime;
            timer3 -= Time.deltaTime;
            if(timer3 <= 0)
            {
                Shoot();
                timer3 = .4f;
            }
            if(timer2 <= 0)
            {
                timer = 5f;
                timer2 = 4f;
                fire = false;
            }
        }
    }
    void Shoot()
    {
        Instantiate(TractorFireball, TractorFlameFirePoint.position, TractorFlameFirePoint.rotation);
    }
}
