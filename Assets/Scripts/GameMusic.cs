using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {
    public AudioSource musicPlayer;

    public void StartMusic()
    {
        musicPlayer.Play();
        musicPlayer.volume = 0.13f;
    }

    public void StopMusic()
    {
        musicPlayer.Stop();
        musicPlayer.volume = 0f;
    }
}
