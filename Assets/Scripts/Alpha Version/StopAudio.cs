using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{      

    public string introToMute;
    public string loopToMute;
    void Awake() {
        FindObjectOfType<AudioManager>().StopIntro(introToMute);
        FindObjectOfType<AudioManager>().StopLoop(loopToMute);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
