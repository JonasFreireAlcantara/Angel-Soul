using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip[] musicasDeFundo;
    void Start()
    {
        AudioClip musicasDeFundoDessaFase = musicasDeFundo[0];
        audioSourceMusicaDeFundo.clip = musicasDeFundoDessaFase;
        audioSourceMusicaDeFundo.loop = true;
        audioSourceMusicaDeFundo.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
