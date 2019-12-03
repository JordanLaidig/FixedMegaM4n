using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JohnsonText : MonoBehaviour
{
    Text JohnsonT;
    GameManager game;
    public Health Johnson;
    // Start is called before the first frame update
    void Start()
    {
        JohnsonT = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JohnsonT.text = Johnson.getHealth().ToString();
    }
}
