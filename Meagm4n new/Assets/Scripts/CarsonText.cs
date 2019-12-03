using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarsonText : MonoBehaviour
{
    Text CarsonT;
    GameManager game;
    public Health Carson;
    // Start is called before the first frame update
    void Start()
    {
        CarsonT = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CarsonT.text = Carson.getHealth().ToString();
    }
}
