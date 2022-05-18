using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassielController : FighterControllerBase
{   
    //Controle de Ataques
    public GameObject sword;
    private bool canAttack = true;
    private float lastAttack = -1;

    //Controle da Magia
    public GameObject spellLaunchPoint;
    public GameObject spellOne;
    private bool spellOneEnable = true;
    private float lastSpellOne = -1;
    // private float direction = 1f;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();

        InitializeHealthAndSpellBars();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0){
             Move();
             Jump();
             Hit();
             SpellOne();
         }
    }

    private void Move(){

        /*Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed; */
        float horizontalInput = Input.GetAxis("Horizontal");

        rigidbody2D.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rigidbody2D.velocity.y);
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        animator.SetBool("move", Mathf.Abs(horizontalInput) > 0f);

        if(horizontalInput > 0f){
            transform.eulerAngles = new Vector3(0f,0f,0f);
            direction = 0f;
        }
        if(horizontalInput < 0f){
            transform.eulerAngles = new Vector3(0f,180f,0f);
            direction = -0f;
        }
    }

    private bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && isGrounded;
    }

    private new void Jump(ForceMode2D forceMode2D = ForceMode2D.Impulse){
        if(CanJump()) {
            base.Jump(forceMode2D);
        }
    }

    private void Hit() {
        if(canAttack) {
            if(Input.GetKeyDown(KeyCode.S)){
                animator.SetBool("attack", true);
                canAttack = false;
                lastAttack = Time.time;
                
            }
        }
        else {
            if(Time.time >= lastAttack + 0.3f) {
                canAttack = true;
            }
            if(Time.time >= lastAttack + 0.15f) {
                animator.SetBool("attack", false);
            }
        }
        
    }

    private void SpellOne(){
        if(spellOneEnable){
            if(Input.GetKeyDown(KeyCode.I) && GetSpellPoints() >= 5){
                spellLaunchPoint.GetComponent<SpellLauncher>().Launch(spellOne, spellLaunchPoint, direction);
                spellOneEnable = false;
                lastSpellOne = Time.time;
                DecreaseSpell(5f);
            }
        }
        else{
            if(Time.time >= lastSpellOne + 0.75f){
                spellOneEnable = true;
            }
        }
    }

}
