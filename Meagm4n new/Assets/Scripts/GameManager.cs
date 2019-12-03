using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int JorgeHP;
    public int JohnsonHP;
    public int JoeHP;
    public int CarsonHP;
    
    // Start is called before the first frame update
    void Start()
    {
        JorgeHP = 100;
    //public int JohnsonHP;
    //public int JoeHP;
    //public int CarsonHP;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
