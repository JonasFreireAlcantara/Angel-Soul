using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //Controle de movimentação
    public float speed;
    public float jumpForce;
    private bool isGrounded;
    private Rigidbody2D rigidbody2D;
    
    //Controle de animação
    private Animator anim;

    //Controle de Ataques
    public GameObject sword;
    private bool canAttack = true;
    private float lastAttack = -1;

    //Controle da Magia
    public GameObject spellLaunchPoint;
    public GameObject spellOne;
    private bool spellOneEnable = true;
    private float lastSpellOne = -1;
    private float direction = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rigidbody2D.velocity.y);

        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("move",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
            direction = 1f;
        }
        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("move",true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
            direction = -1f;
        }
        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("move",false);
        }
    }

    private bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && isGrounded;
    }

    protected void Jump(ForceMode2D forceMode2D = ForceMode2D.Impulse){
        if(CanJump())
            rigidbody2D.AddForce(Vector2.up * jumpForce, forceMode2D);
    }

    private void Hit(){
        if(canAttack){
            if(Input.GetKeyDown(KeyCode.S)){
                anim.SetBool("attack", true);
                canAttack = false;
                lastAttack = Time.time;
            }
        }
        else{
            if(Time.time >= lastAttack + 0.3f){
                canAttack = true;
            }
            if(Time.time >= lastAttack + 0.15f){
                anim.SetBool("attack",false);
            }
                
        }
        
    }

    private void SpellOne(){
        if(spellOneEnable){
            if(Input.GetKeyDown(KeyCode.I)){
                spellLaunchPoint.GetComponent<SpellLauncher>().Launch(spellOne, spellLaunchPoint, direction);
                spellOneEnable = false;
                lastSpellOne = Time.time;
            }
        }
        else{
            if(Time.time >= lastSpellOne + 0.75f){
                spellOneEnable = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.GROUND))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.GROUND))
        {
            isGrounded = false;
        }
    }

}
