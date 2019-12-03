using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionLeft : MonoBehaviour
{
    public CameraController cam;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            cam.movable = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            cam.movable = true;
        }
    }
}
