using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnsonBar : MonoBehaviour
{
    public Transform bar;
    public GameManager game;
    void Start()
    {
        bar = transform.Find("JohnsonHBar");
    }

    public void SetSize(float n)
    {
        bar = transform.Find("JohnsonHBar");
        bar.localScale = new Vector3(n, 1);
    }
    public void FixedUpdate()
    {
        SetSize(game.JohnsonHP * .01f);
    }
}
