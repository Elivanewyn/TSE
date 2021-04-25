using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetSFXVolume (float volume)
    {
        mainMixer.SetFloat("SFX", volume);
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("Music", volume);
    }
}
