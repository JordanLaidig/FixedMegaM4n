using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGaame()
    {
        SceneManager.LoadScene("JonathanGalon Scene");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("JonathanGalon Scene3");
    }
}
