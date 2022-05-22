using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelphegorIdleAnimation : StateMachineBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rigidbody2D;
    private BelphegorController belphegorController;
    private float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        rigidbody2D = animator.GetComponent<Rigidbody2D>();
        belphegorController = animator.GetComponent<BelphegorController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(belphegorController.IsPlayerInsideAttackRange()){
           belphegorController.Attack();
       }
    }

}