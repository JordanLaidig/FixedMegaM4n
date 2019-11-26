using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsonWeapon : MonoBehaviour
{
    public Transform CarsonsFirePoint;
    public GameObject firePreFab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(firePreFab, CarsonsFirePoint.position, CarsonsFirePoint.rotation);
    }
}
