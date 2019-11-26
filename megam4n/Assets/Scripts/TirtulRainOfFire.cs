using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirtulRainOfFire : MonoBehaviour
{
    public Transform TirtulFirePoint;

    public GameObject firePreFab;

    private float timer = 3f;

    void Shoot()
    {
        Instantiate(firePreFab, TirtulFirePoint.position, TirtulFirePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 3f;
            Shoot(); // Spawn Bullet or whatever else
        }
    }
}
