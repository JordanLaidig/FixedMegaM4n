﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class collisionTop : MonoBehaviour
{
    public Camera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.GetComponent<CameraController>().movable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            cam.GetComponent<CameraController>().movable = true;
        }
    }
}
