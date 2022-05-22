using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanController : EnemyControllerBase
{

    public void Awake()
    {
        FindObjectOfType<AudioManager>().StopIntro("Mammon_intro");
        FindObjectOfType<AudioManager>().StopLoop("Mammon_loop");
        FindObjectOfType<AudioManager>().IntroPlay("WATER_CAVE_intro");
        FindObjectOfType<AudioManager>().LoopPlay("WATER_CAVE_loop");
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InitializeHealthAndSpellBars();
    }

    void Update()
    {
        
    }
}
