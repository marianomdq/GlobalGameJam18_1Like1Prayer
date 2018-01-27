using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

    public void BeginGameCall()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu1":
                SceneManager.LoadScene("Main");
                break;
            case "Menu2":
                SceneManager.LoadScene("Level2");
                break;
            case "Menu3":
                SceneManager.LoadScene("Level3");
                break;
        }
    }
}
