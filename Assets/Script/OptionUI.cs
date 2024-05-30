using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioSource musicManager;
    private TextMeshProUGUI soundText, musicText;
    private int soundVolume =5 ,musicVolume= 5;

    private void Awake()
    {

        transform.Find("Sound").Find("increasebtn").GetComponent<Button>().onClick.AddListener(()=>{
            
            soundVolume++;
            soundManager.AdjustVolume(soundVolume);
            SoundSetText();

        });
        
        transform.Find("Sound").Find("decreasebtn").GetComponent<Button>().onClick.AddListener(()=>{
            
            soundVolume--;
            soundManager.AdjustVolume(soundVolume);
            SoundSetText();
        });
        soundText=transform.Find("Sound").Find("soundtext").GetComponent<TextMeshProUGUI>();
        transform.Find("Music").Find("increasebtn").GetComponent<Button>().onClick.AddListener(()=>{
         
            IncreaseMusicVolume(musicVolume);
            MusicSetText();
        });
        
        transform.Find("Music").Find("decreasebtn").GetComponent<Button>().onClick.AddListener(()=>{
            
            DcreaseMusicVolume(musicVolume);
            MusicSetText();

        });
        musicText=transform.Find("Music").Find("musictext").GetComponent<TextMeshProUGUI>();
      



    }
    private void Start()
    {
       
        soundManager.AdjustVolume(soundVolume);
        musicManager.volume =(float) musicVolume/10;
        SoundSetText();
        MusicSetText();
    }    

    private void SoundSetText()
    {
        soundText.SetText(soundManager.AudioVolume().ToString());
    }
    private void MusicSetText()
    {
        float volume =musicManager.volume;
        musicText.SetText((volume*10).ToString());
    }
    private void IncreaseMusicVolume(int volume)
    {
        volume++;
        musicVolume = Mathf.Clamp(volume,0,10);
        musicManager.volume =(float) musicVolume/10;

    }
    private void DcreaseMusicVolume(int volume)
    {
        volume --;
        musicVolume = Mathf.Clamp(volume,0,10);
        musicManager.volume =(float) musicVolume/10;
        
    }
    

}
