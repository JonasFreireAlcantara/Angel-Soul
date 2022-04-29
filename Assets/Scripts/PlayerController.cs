using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FighterControllerBase
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxis("Horizontal"));

        if (CanJump())
        {
            Jump();
        }
    }

    private bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && !isGrounded;
    }

}
