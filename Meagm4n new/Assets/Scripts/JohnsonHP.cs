using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JohnsonHP : MonoBehaviour
{
    GameManager game;
    Image health;
    public Health Johnson;
    void Start()
    {
        health = GameObject.Find("ContentJohnson").GetComponent<Image>();
    }

    public void FixedUpdate()
    {
        health.fillAmount = Johnson.getHealth() / 100f;
    }
}
