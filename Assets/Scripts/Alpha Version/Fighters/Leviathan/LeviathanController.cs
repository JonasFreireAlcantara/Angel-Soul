using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanController : EnemyControllerBase
{
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
