using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {
    public AudioSource musicPlayer;
    public AudioClip summer;
    public AudioClip resilience;

    public void StartMusic()
    {
        musicPlayer.clip = summer;

        musicPlayer.Play();
        musicPlayer.volume = 0.13f;
    }

    public void SwapTrack()
    {
        musicPlayer.Stop();
        musicPlayer.volume = 0f;

        //Load up the Resilience song
        musicPlayer.clip = resilience;

        musicPlayer.Play();
        musicPlayer.volume = 0.13f;
    }

    public void StopMusic()
    {
        musicPlayer.Stop();
        musicPlayer.volume = 0f;
    }
}
