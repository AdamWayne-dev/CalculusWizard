using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] levelMusicTracks;
    [SerializeField] AudioSource levelAudioSource;
    AudioClip currentLevelSong;
    private bool isPlaying;
    
    void Start()
    {
        isPlaying = false;
    }

    
    void Update()
    {
        
    }

    public void PlayBackgroundMusic(int trackNumber)
    {
        if (!isPlaying)
        {
            currentLevelSong = levelMusicTracks[trackNumber];
            levelAudioSource.clip = currentLevelSong;
            levelAudioSource.Play();
            isPlaying = true;
        }
    }

    public void SetIsPlayingMusic(bool state)
    {
        isPlaying = state;
    }
}
