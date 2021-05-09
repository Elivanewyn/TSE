using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        //Debug.Log("Played");
    }
}
