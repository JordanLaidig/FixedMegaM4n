using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoesWeapon : MonoBehaviour
{
    public Transform JoesFirePoint;
    public GameObject firePreFab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("/"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(firePreFab, JoesFirePoint.position, JoesFirePoint.rotation);
    }
}
