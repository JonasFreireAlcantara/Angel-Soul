using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamonController : EnemyControllerBase
{
    public float swordAttackRange;
    private float lastAttack = -1;
    private bool canAttack = true;
    public Transform swordAttackPoint;
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

            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(swordAttackPoint.position, swordAttackRange, playerLayer);

            foreach(Collider2D player in hitPlayers)
            {
                player.GetComponent<CassielController>().DecreaseLife(20f);
            }
            
            canAttack = false;
            lastAttack = Time.time;
        }
        else {
            if(Time.time >= lastAttack + 1f)
                canAttack = true;
        }
        
    }

    public bool IsPlayerInsideSwordAttackRange()
    {
        return Vector2.Distance(player.position, swordAttackPoint.position) <= swordAttackRange;
    }

    void OnDrawGizmosSelected()
    {
        if (swordAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(swordAttackPoint.position, swordAttackRange);
    }

}
