using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int coinAmount=0;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject coinUI;
    [SerializeField] private GameObject deadUIContainer , winUIContainer , gameWinUI;
    [SerializeField] private List<GameObject> levelList;
    [SerializeField]private int levelCount =0;


    public event EventHandler OnNewLevelStarted;

    private void Awake()
    {
        player.GetComponent<PlayerController>().OnCoinCollected += OnCoinCollectedby_Player;
        player.GetComponent<PlayerController>().OnPlayerDeath+= Player_DeadUI;
        player.GetComponent<PlayerController>().OnLevelCompleted+= Player_LevelCompletd;
        gameWinUI.transform.Find("MainMenubtn").GetComponent<Button>().onClick.AddListener(()=>{SceneManager.LoadScene(0);});
    }

    private void Player_LevelCompletd(object sender, EventArgs e)
    {

        winUIContainer.SetActive(true);
        winUIContainer.transform.Find("cointext").GetComponent<TextMeshProUGUI>().SetText("Your Coin : {0}",coinAmount);
        


    }
   

    private void Player_DeadUI(object sender, EventArgs e)
    {
        player.SetActive(false);
        deadUIContainer.SetActive(true);
    }

    private void OnCoinCollectedby_Player(object sender, EventArgs e)
    {
        IncreseCoinAmount();
        coinUI.GetComponent<CoinUI>().ChangeCoin(coinAmount);
    }
    private void IncreseCoinAmount()
    {

        coinAmount++;
    }
    private void Start() {
        foreach(GameObject level in levelList)
        {
            level.SetActive(false);
        }
        ChangeLevel(levelCount);
    }
    private void ChangeLevel( int levelCount)
    {
        winUIContainer.SetActive(false);
        deadUIContainer.SetActive(false);
        levelList[levelCount].SetActive(true);
    }
    public void IncreaseLevel()
    {
        foreach (GameObject level in levelList)
        {
            level.SetActive(false);
        }
        levelCount++;
         levelCount =Mathf.Clamp(levelCount,0,levelList.Capacity);
        if(levelCount == levelList.Capacity)
        {
            winUIContainer.SetActive(false);
            gameWinUI.SetActive(true);
            player.SetActive(false);

        }
        else{
             ChangeLevel(levelCount);
             OnNewLevelStarted?.Invoke(this, EventArgs.Empty);
        }

        
    }
    public void RetryLevel()
    {
         foreach (GameObject level in levelList)
        {
            level.SetActive(false);
        }
        levelList[levelCount].SetActive(true);
        deadUIContainer.SetActive(false);
        player.SetActive(true);
        player.transform.position = new Vector3(0, 0,0);
    }
}
