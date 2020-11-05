using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{

    public static AudioSource source;
    public List<AudioClip> sfxList;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

}
