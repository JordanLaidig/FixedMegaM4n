using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorgeBar : MonoBehaviour
{
    public Transform bar;
    public GameManager game;
    void Start()
    {
        bar = transform.Find("JorgeHBar");
    }

    public void SetSize(float n)
    {
        bar = transform.Find("JorgeHBar");
        bar.localScale = new Vector3(n, 1);
    }
    public void FixedUpdate()
    {
        SetSize(game.JorgeHP * .01f);
    }
}
