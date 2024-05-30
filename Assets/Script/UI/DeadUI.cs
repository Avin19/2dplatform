using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadUI : MonoBehaviour
{
    [SerializeField] GameObject  deadUIContainer ,gameManager;
   

    private void Awake() {
        deadUIContainer.SetActive(false);
        transform.Find("Container").Find("retrybtn").GetComponent<Button>().onClick.AddListener(() => { gameManager.GetComponent<GameManager>().RetryLevel(); });
        transform.Find("Container").Find("mainmenubtn").GetComponent<Button>().onClick.AddListener(()=>{SceneManagerController.Instance.ReloadScene();});
    }
}
