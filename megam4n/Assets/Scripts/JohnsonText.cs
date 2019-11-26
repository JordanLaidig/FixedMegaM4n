using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JohnsonText : MonoBehaviour
{
    public static int JohnsonTextHP = 100;
    Text JohnsonT;
    GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        JohnsonT = GetComponent<Text>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        JohnsonT.text = game.JohnsonHP.ToString();
    }
}
