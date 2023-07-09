using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource musicSource;

    private float musicVolumeLevel = 1;
    private float gameEffectsVolumeLevel = 1;

    public static string MUSIC_VOLUME = "MusicVolume";
    public static string SFX_VOLUME = "SFXVolume";

    void Start()
    {
        musicSource.ignoreListenerPause = true;
    }

    public void SetVolume(string volumeParam, float sliderValue)
    {
        audioMixer.SetFloat(volumeParam, Mathf.Log10(sliderValue) * 20);
        if (volumeParam.Equals(MUSIC_VOLUME)) musicVolumeLevel = sliderValue;
        if (volumeParam.Equals(SFX_VOLUME)) gameEffectsVolumeLevel = sliderValue;
    }

    public float GetVolumeLevel(string volumeType)
    {
        if (volumeType.Equals(MUSIC_VOLUME)) return musicVolumeLevel;
        if (volumeType.Equals(SFX_VOLUME)) return gameEffectsVolumeLevel;
        return 1;
    }
}
