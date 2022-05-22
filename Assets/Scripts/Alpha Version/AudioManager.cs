using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sounds[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }

        foreach (Sounds Intro in sounds)
        {
            Intro.introAudio = gameObject.gameObject.AddComponent<AudioSource>();
            Intro.introAudio.clip = Intro.intro;

            Intro.introAudio.volume = Intro.volume;
            Intro.introAudio.pitch = Intro.pitch;

        }

        foreach (Sounds Iloop in sounds)
        {
            Iloop.loopAudio = gameObject.gameObject.AddComponent<AudioSource>();
            Iloop.loopAudio.clip = Iloop.iloop;

            Iloop.loopAudio.volume = Iloop.volume;
            Iloop.loopAudio.pitch = Iloop.pitch;
            Iloop.loopAudio.loop = Iloop.loop;

        }

    }

    void Start()
    {
        IntroPlay("Intro_intro");
        LoopPlay("Intro_loop");
        //Play("Estagio_1"); 
    }

    // Update is called once per frame
    public void PlayAudio(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
        }
        s.source.Play();
    }

    public void IntroPlay(string name)
    {
        Sounds Intro = Array.Find(sounds, Intro => (Intro.name + "_intro") == name);
        if (Intro == null)
        {
            Debug.LogWarning("Intro: " + name + "not found");
        }

        Intro.introAudio.Play();
    }

    public void LoopPlay(string name)
    {
        Sounds Iloop = Array.Find(sounds, Iloop => (Iloop.name + "_loop") == name);
        if (Iloop == null)
        {
            Debug.LogWarning("Loop: " + name + " not Found");
        }
        int LoopIndex = Array.IndexOf(sounds, Iloop);
        Iloop.loopAudio.PlayDelayed(sounds[LoopIndex].introAudio.clip.length);

    }

    //Parar Audios
    public void StopAudio(string sound)
    {
        Sounds s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));

        s.source.Stop();
    }

    public void StopIntro(string sound)
    {
        Sounds Intro = Array.Find(sounds, item => (item.name + "_intro") == sound);
        if (Intro == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        Intro.loopAudio.volume = Intro.volume * (1f + UnityEngine.Random.Range(-Intro.volume / 2f, Intro.volume / 2f));
        Intro.loopAudio.pitch = Intro.pitch * (1f + UnityEngine.Random.Range(-Intro.pitch / 2f, Intro.pitch / 2f));

        Intro.introAudio.Stop();
    }
    public void StopLoop(string sound)
    {
        Sounds ILoop = Array.Find(sounds, item => (item.name + "_loop") == sound);
        if (ILoop == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        ILoop.loopAudio.volume = ILoop.volume * (1f + UnityEngine.Random.Range(-ILoop.volume / 2f, ILoop.volume / 2f));
        ILoop.loopAudio.pitch = ILoop.pitch * (1f + UnityEngine.Random.Range(-ILoop.pitch / 2f, ILoop.pitch / 2f));

        ILoop.loopAudio.Stop();
    }
}
