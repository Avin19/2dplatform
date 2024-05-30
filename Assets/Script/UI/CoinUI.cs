using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    
    private TextMeshProUGUI coinText;
    [SerializeField]private GameObject optionUIMenu;
    private void Awake() {
       
       coinText = transform.Find("coinText").GetComponent<TextMeshProUGUI>();
       transform.Find("optionmenubtn").GetComponent<Button>().onClick.AddListener(() => {
        optionUIMenu.SetActive(!optionUIMenu.activeSelf);
       });
       
       
       
    }

    private void Start() {
        ChangeCoin(0);
        optionUIMenu.SetActive(false);
    }
    private void Update()
    {
        if(optionUIMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    
    }
    public void ChangeCoin(int coin)
    {
        coinText.SetText(coin.ToString());

    }
    
}
