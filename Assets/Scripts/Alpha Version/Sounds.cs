using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{

    public string name;
    public int introIndex;
    public AudioClip clip;
    public AudioClip intro;
    public AudioClip iloop;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public AudioSource introAudio;
    [HideInInspector]
    public AudioSource loopAudio;



}
