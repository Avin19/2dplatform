using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelCompleted : MonoBehaviour
{
    [SerializeField] private GameObject  winUIContainer ,gameManager;
   
   
   

    private void Awake() {
        
        
        transform.Find("Container").Find("nextbtn").GetComponent<Button>().onClick.AddListener(() =>{ 
            gameManager.GetComponent<GameManager>().IncreaseLevel();
        });
        transform.Find("Container").Find("mainmenubtn").GetComponent<Button>().onClick.AddListener(()=>{SceneManagerController.Instance.ReloadScene();});
        winUIContainer.SetActive(false);
    }
    


   
}
