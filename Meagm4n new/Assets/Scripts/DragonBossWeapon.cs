using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossWeapon : MonoBehaviour
{
    public Transform DragonBossFirePoint;

    public GameObject DragonBossFirePreFab;

    public float timer = 3f;

    void Shoot()
    {
        Instantiate(DragonBossFirePreFab, DragonBossFirePoint.position, DragonBossFirePoint.rotation);
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
