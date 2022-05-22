using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelphegorController : EnemyControllerBase
{
    public float attackRange;
    private float lastAttack = -1f;
    private bool canAttack = true;
    private float habilityOneLastCast = 15f;
    private bool habilityOneinCooldown = true;
    private float habilityOneCooldown = 10f;
    private bool secondPhase = false;
    public Transform attackPoint;
    public LayerMask playerLayer;

    // Start is called before the first frame update
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

            //HabilityOne();
        }
    }

    private bool CanJump()
    {
        return isGrounded;
    }

    public void SwordAttack()
    {
        if(canAttack){
            animator.SetTrigger("attack");

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
            animator.SetTrigger("cast");
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
        return Vector2.Distance(player.position, attackPoint.position) <= attackRange;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
