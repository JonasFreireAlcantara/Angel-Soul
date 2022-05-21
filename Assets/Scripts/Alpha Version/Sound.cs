using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour
{
    public new string name;
    public string introIndex;
    public AudioClip clip;
    public AudioClip intro;
    public AudioClip iloop;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioClip source;
    [HideInInspector]
    public AudioSource introAudio;
    [HideInInspector]
    public AudioSource loopAudio;
}
