using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{


    public static SceneManagerController Instance { get; private set;}

    private void Awake() {
        Instance = this;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
