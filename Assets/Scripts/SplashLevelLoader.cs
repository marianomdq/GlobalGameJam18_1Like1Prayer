﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLevelLoader : MonoBehaviour {
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
