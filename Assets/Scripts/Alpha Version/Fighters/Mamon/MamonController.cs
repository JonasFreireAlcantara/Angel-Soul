using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamonController : EnemyControllerBase
{
    public float swordAttackRange;
    private float lastAttack = -1;
    private bool canAttack = true;
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
        LookAtPlayer();

        if (CanJump())
        {
            Jump(ForceMode2D.Force);
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

            this.gameObject.GetComponent<CastHability>().Cast(isFlipped ? 1 : -1, this.gameObject, 0);
            
            canAttack = false;
            lastAttack = Time.time;
        }
        else {
            if(Time.time >= lastAttack + 1.5f)
                canAttack = true;
        }
        
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
