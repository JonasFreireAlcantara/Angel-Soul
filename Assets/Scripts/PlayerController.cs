using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FighterControllerBase
{   
    public GameObject sword;
    private bool originalPosition = true;
    private bool canAttack = true;
    private float lastAttack = -1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0){
            Move(Input.GetAxis("Horizontal"));
            Jump();
            Hit();
        }
    }

    private bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && !isGrounded;
    }

    protected void Jump(ForceMode2D forceMode2D = ForceMode2D.Impulse)
    {
        if(CanJump())
            rigidbody2D.AddForce(Vector2.up * jumpForce, forceMode2D);
    }

    private void Hit(){
        if(canAttack){
            if(Input.GetKeyDown(KeyCode.S)){
                sword.transform.Rotate(new Vector3(0f,0f, 90f)); 
                canAttack = false;
                lastAttack = Time.time;
                originalPosition = false;
            }
        }
        else{
            if(Time.time >= lastAttack + 0.3f){
                canAttack = true;
            }
            if(!originalPosition && Time.time >= lastAttack + 0.15f){
                sword.transform.Rotate(new Vector3(0f,0f, 90f));
                originalPosition = true;
            }
                
        }
        
    }

}
