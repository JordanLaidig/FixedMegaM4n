﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JousterAi : MonoBehaviour
{
    public float speed;
    private bool movingLeft = true;
    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        Health health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }
}
