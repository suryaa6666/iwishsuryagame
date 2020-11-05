using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource source;
    public List<AudioClip> music;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = music[Random.Range(0, music.Count)];
        source.Play();
    }


}
