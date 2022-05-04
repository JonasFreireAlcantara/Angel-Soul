using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : FighterControllerBase
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        InitializeHealthAndSpellBars();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanJump())
        {
            Jump(ForceMode2D.Force);
        }
    }

    private bool CanJump()
    {
        return !isGrounded;
    }



}
