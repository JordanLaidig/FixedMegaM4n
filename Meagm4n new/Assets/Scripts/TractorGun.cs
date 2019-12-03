using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorGun : MonoBehaviour
{
    public Transform TractorGunFirePoint;
    public GameObject TractorGunProjectile;
    public float timer = .5f;

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
            timer = .5f;
            Shoot(); // Spawn Bullet or whatever else
        }
    }
    void Shoot()
    {
        Instantiate(TractorGunProjectile, TractorGunFirePoint.position, TractorGunFirePoint.rotation );
    }
}
