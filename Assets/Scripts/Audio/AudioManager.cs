using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class AudioManager : Singleton<AudioManager>
{
    public List<MusicSetup> musicSetups;
    public KeyCode onOffButton;
    public GameObject audios;

    private bool _isActive = true;

    private void Update()
    {
        if (Input.GetKeyDown(onOffButton))
        {
            OnOffSound();
        }
    }

    public void OnOffSound()
    {
        if(_isActive == true)
        {
            _isActive = false;
            audios.SetActive(false);
        }
        else if(_isActive == false)
        {
            _isActive = true;
            audios.SetActive(true);
        }
    }

    public MusicSetup GetMusicByType(MusicType type)
    {
        return musicSetups.Find(i => i.musicType == type);
    }
}

public enum MusicType
{
    MENU,
    LEVEL_01,
    LEVEL_02,
    LEVEL_03
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip musicClip;
}