using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("play").GetComponent<Button>().onClick.AddListener(() =>{SceneManager.LoadScene(1);});
        transform.Find("quit").GetComponent<Button>().onClick.AddListener(() =>{Application.Quit();});
    }
}
