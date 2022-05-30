using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassielController : FighterControllerBase
{   
    //Controle de Ataques
    public GameObject sword;
    public GameObject hitPrefab;
    private bool canAttack = true;
    private float lastAttack = -1;

    private float lastJump = -1;

    private int numberOfAvailableJumps = 2;

    public bool isSleeping = false;
    private float timeSleeped;
    private float timeToSleep;
    private float initialTimeSleep;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        InitializeHealthAndSpellBars();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0 && !isSleeping){
            if(!isDefending){
                Move();
                Jump();
                SwordAttack();  
            }
            Defense();
        }
        else if (isSleeping){
            timeSleeped = Time.time - initialTimeSleep;
            timeToSleep -= timeSleeped;

            if(timeToSleep <= 0){
                AwakeFromSleep();
            }
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
        return Input.GetKeyDown(KeyCode.Space) && numberOfAvailableJumps > 0 && Time.time > lastJump + 0.45f;
    }

    private new void Jump(ForceMode2D forceMode2D = ForceMode2D.Impulse){
        if(CanJump()) {
            numberOfAvailableJumps -= 1;
            if (numberOfAvailableJumps == 0) {
                animator.SetTrigger("doubleJump");
            }
            lastJump = Time.time;
            base.Jump(forceMode2D);
        }
    }

    private void SwordAttack() {
        if (Input.GetKeyDown(KeyCode.T) && canAttack) {
            lastAttack = Time.time;
            animator.SetTrigger("attack");
            canAttack = false;
            sword.GetComponent<CassielSword>().setAttacking(true);
        }
        else{
            if (Time.time >= lastAttack + 0.5f){
                canAttack = true;
            }
        }
    }

    public override void Landed() {
        numberOfAvailableJumps = 2;
    }

    public void Defense() {
        if (Input.GetKey(KeyCode.Y) && numberOfAvailableJumps == 2) {
            isDefending = true;
            animator.SetBool("defense", true);
        } else {
            isDefending = false;
            animator.SetBool("defense", false);
        }
    }

    public void Sleep(float timeToSleep){
        isSleeping = true;
        timeSleeped = 0f;
        this.timeToSleep = timeToSleep;
        initialTimeSleep = Time.time;
    }

    public void AwakeFromSleep(){
        isSleeping = false;
        timeToSleep = 0;
    }

}
