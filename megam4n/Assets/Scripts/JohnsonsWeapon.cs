using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnsonsWeapon : MonoBehaviour
{
    public Transform JohnsonsFirePoint;
    public GameObject firePreFab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(firePreFab, JohnsonsFirePoint.position, JohnsonsFirePoint.rotation);
    }
}
