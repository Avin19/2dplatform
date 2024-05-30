using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private PlayerController player;
    [SerializeField]private List<AudioClip> audioClips;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        

    }
    private void Start()
    {
        player.OnCoinCollected += OnCoinCollected;
        player.OnLevelCompleted += Player_OnLevelCompleted;
        player.OnPlayerDeath += Player_OnDeath;
        player.OnPlayerJump+= Player_OnJump;
        
    }
    public float AudioVolume()
    {
        return audioSource.volume*10;
    }
    public void AdjustVolume(int volume)
    {
        volume = Mathf.Clamp(volume,0,10);
        audioSource.volume = (float) volume/10;
    }

    private void Player_OnJump(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(audioClips[1]);
    }

    private void Player_OnDeath(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(audioClips[2]);
    }

    private void Player_OnLevelCompleted(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(audioClips[3]);
    }

    private void OnCoinCollected(object sender, EventArgs e)
    {
       audioSource.PlayOneShot(audioClips[0]);
    }
}
