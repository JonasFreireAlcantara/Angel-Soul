using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelWalkAnimation : StateMachineBehaviour
{

    private Transform playerTransform;
    private Rigidbody2D rigidbody2D;
    private AzazelController azazelController;
    private float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        rigidbody2D = animator.GetComponent<Rigidbody2D>();
        azazelController = animator.GetComponent<AzazelController>();
        speed = azazelController.speed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveTowardPlayer();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    private void MoveTowardPlayer()
    {
        Vector2 target = new Vector2(playerTransform.position.x, rigidbody2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, speed * Time.fixedDeltaTime);
        rigidbody2D.MovePosition(newPosition);
    }
}
