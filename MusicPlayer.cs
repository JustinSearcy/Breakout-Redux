using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float musicVolume = 0.8f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume;
    }
}
