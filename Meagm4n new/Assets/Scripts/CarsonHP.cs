using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarsonHP : MonoBehaviour
{
    GameManager game;
    Image health;
    public Health Carson;
    void Start()
    {
        health = GameObject.Find("ContentCarson").GetComponent<Image>();
    }

    public void FixedUpdate()
    {
        health.fillAmount = Carson.getHealth() / 100f;
    }
}
