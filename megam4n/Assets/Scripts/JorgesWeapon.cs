using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorgesWeapon : MonoBehaviour
{
    public Transform JorgesFirePoint;
    public GameObject firePreFab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        Instantiate(firePreFab, JorgesFirePoint.position, JorgesFirePoint.rotation);
    }
}
