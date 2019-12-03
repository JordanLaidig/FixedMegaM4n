using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JorgeHP : MonoBehaviour
{
    GameManager game;
    Image health;
    public Health Jorge;
    void Start()
    {
        health = GameObject.Find("Content").GetComponent<Image>();
    }

    public void FixedUpdate()
    {
        health.fillAmount = Jorge.getHealth() / 100f;
    }
}
