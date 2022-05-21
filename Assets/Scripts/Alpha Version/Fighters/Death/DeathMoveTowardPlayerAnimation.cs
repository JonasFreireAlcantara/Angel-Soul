using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMoveTowardPlayerAnimation : StateMachineBehaviour
{
    private Transform playerTransform;
    private Transform deathTransform;
    private DeathController deathController;
    private float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        deathTransform = animator.GetComponent<Transform>();
        deathController = animator.GetComponent<DeathController>();
        speed = animator.GetComponent<DeathController>().speed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       FloatTowardPlayer();
       deathController.RandomAttack();
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

    private void FloatTowardPlayer()
    {
        Vector2 playerPosition = playerTransform.position;
        Vector2 newPosition = Vector2.MoveTowards(deathTransform.position, playerPosition, speed * Time.fixedDeltaTime);
        deathTransform.position = newPosition;
    }

}
