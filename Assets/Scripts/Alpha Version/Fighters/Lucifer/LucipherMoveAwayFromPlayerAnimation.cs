using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucipherMoveAwayFromPlayerAnimation : StateMachineBehaviour
{

    private Transform playerTransform;
    private Rigidbody2D rigidbody2D;
    private LucipherController lucipherController;
    private float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        rigidbody2D = animator.GetComponent<Rigidbody2D>();
        lucipherController = animator.GetComponent<LucipherController>();
        speed = animator.GetComponent<LucipherController>().speed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       MoveAwayFromThePlayer();
       lucipherController.RandomAttackRay();
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

    private void MoveAwayFromThePlayer()
    {
        Vector2 target = new Vector2(playerTransform.position.x, rigidbody2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, -1 * speed * Time.fixedDeltaTime);
        rigidbody2D.MovePosition(newPosition);
    }

}
