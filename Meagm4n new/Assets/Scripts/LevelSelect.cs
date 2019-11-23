using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("JonathanGalon Scene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("JonathanGalon Scene2");
    }
}
