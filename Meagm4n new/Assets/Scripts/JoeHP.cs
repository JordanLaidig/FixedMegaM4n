using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoeHP : MonoBehaviour
{
    GameManager game;
    Image health;
    public Health Joe;
    void Start()
    {
        health = GameObject.Find("ContentJoe").GetComponent<Image>();
    }

    public void FixedUpdate()
    {
        health.fillAmount = Joe.getHealth() / 100f;
    }
}
