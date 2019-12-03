using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    GameManager game;
    Image health;
    void Start()
    {
        health = GameObject.Find("Content").GetComponent<Image>();
        game.JorgeHP = 25;
        health.fillAmount = 20f;
    }

    public void FixedUpdate()
    {
        health.fillAmount = game.JorgeHP / 100f;
    }
}
