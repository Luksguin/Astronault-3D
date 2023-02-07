using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public MusicType musicType;
    public AudioSource audioSource;

    private MusicSetup _currentAudio;

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        _currentAudio = AudioManager.instance.GetMusicByType(musicType);
        audioSource.clip = _currentAudio.musicClip;
        audioSource.Play();
    }
}
