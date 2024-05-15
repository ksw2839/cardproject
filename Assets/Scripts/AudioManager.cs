using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgmSound;
    void Start()
    {
        audioSource.clip = bgmSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
