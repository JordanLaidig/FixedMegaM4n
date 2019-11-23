using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("level 1 main");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("JonathanGalon Scene2");
    }
}
