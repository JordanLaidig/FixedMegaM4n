using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JorgeText : MonoBehaviour
{
    Text JorgeT;
    GameManager game;
    public Health Jorge;
    // Start is called before the first frame update
    void Start()
    {
        JorgeT = GetComponent<Text>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        JorgeT.text = Jorge.getHealth().ToString();
    }
}
