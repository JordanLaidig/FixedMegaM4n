using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoeText : MonoBehaviour
{
    Text JoeT;
    GameManager game;
    public Health Joe;
    // Start is called before the first frame update
    void Start()
    {
        JoeT = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoeT.text = Joe.getHealth().ToString();
    }
}
