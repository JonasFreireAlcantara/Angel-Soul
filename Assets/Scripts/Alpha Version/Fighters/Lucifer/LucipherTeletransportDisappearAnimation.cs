using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucipherTeletransportDisappearAnimation : StateMachineBehaviour
{
    private LucipherController lucipherController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject boss = GameObject.FindGameObjectWithTag(Tag.ENEMY);
        boss.SetActive(false);
        lucipherController = boss.GetComponent<LucipherController>();

        InactiveGameObject.boss = boss;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPosition = lucipherController.GetNextTeletransportPosition();
        newPosition = new Vector2(newPosition.x, newPosition.y + 2.80f);
        
        animator.GetComponent<Transform>().position = newPosition;
    }

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
}
