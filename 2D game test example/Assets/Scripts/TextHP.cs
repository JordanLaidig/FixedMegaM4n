using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHP : MonoBehaviour
{
    public static int JorgeTextHP = 100;
    Text JorgeText;
    GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        JorgeText = GetComponent<Text>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        JorgeText.text = game.JorgeHP.ToString();
    }
}
