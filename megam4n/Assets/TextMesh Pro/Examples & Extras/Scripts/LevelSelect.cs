﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level 1 main");
    }

    public void PlayFarmLevel()
    {
        SceneManager.LoadScene("Farm level main");
    }
}
