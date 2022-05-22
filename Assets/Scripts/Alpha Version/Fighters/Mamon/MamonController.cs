using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamonController : EnemyControllerBase
{
    public float swordAttackRange;
    private float lastAttack = -1f;
    private bool canAttack = true;
    private float habilityOneLastCast = 15f;
    private bool habilityOneinCooldown = true;
    private float habilityOneCooldown = 10f;
    private bool secondPhase = false;
    public Transform attackPoint;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    public void Awake()
    {
        FindObjectOfType<AudioManager>().IntroPlay("Mammon_intro");
        FindObjectOfType<AudioManager>().LoopPlay("Mammon_loop");
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InitializeHealthAndSpellBars();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.timeScale > 0f){
            LookAtPlayer();
            if(!secondPhase){
                if(GetHealthPoints() <= healthBar.GetMaxValue()/2){
                    ActiveSecondPhase();
                }
            }
            if (CanJump())
            {
                Jump(ForceMode2D.Force);
            }

            HabilityOne();
        }
        
    }

    private bool CanJump()
    {
        return isGrounded;
    }

    public void SwordAttack()
    {
        if(canAttack){
            animator.SetTrigger("Attack");

            this.gameObject.GetComponent<CastHability>().Cast(isFlipped ? 1 : -1, this.gameObject.transform, 0);
            
            canAttack = false;
            lastAttack = Time.time;
        }
        else {
            if(Time.time >= lastAttack + 1.5f)
                canAttack = true;
        }
        
    }

    void HabilityOne(){
        if (!habilityOneinCooldown && spellBar.GetValue() > 5f){
            habilityOneLastCast = Time.time;
            animator.SetTrigger("Cast");
            this.gameObject.GetComponent<CastHability>().Cast(isFlipped ? -1 : 1, player.transform, 1);

            habilityOneinCooldown = true;
            DecreaseSpell(5f);
            
        }
        else{
            if(Time.time >= habilityOneLastCast + habilityOneCooldown){
                habilityOneinCooldown = false;
            }
        }
    }

    void ActiveSecondPhase(){
        secondPhase = true;
        habilityOneCooldown = 5f;
    }

    public void SpellVamp(float lifeStealed, float manaStealed){
        if(life + lifeStealed >= healthBar.GetMaxValue()){
            life = healthBar.GetMaxValue();
        }
        else{
            life += lifeStealed;
        }

        healthBar.SetValue(life);
        
        if(spell + manaStealed >= spellBar.GetMaxValue()){
            spell = spellBar.GetMaxValue();  
        }
        else{
            spell += manaStealed;
        }

        spellBar.SetValue(spell);
    }

    public bool IsPlayerInsideAttackRange()
    {
        return Vector2.Distance(player.position, attackPoint.position) <= swordAttackRange;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, swordAttackRange);
    }

}
