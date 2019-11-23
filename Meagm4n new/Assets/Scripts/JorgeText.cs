using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JorgeText : MonoBehaviour
{
    public static int JorgeTextHP = 100;
    Text JorgeT;
    GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        JorgeT = GetComponent<Text>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        JorgeT.text = game.JorgeHP.ToString();
    }
}
