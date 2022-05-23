using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucipherTeletransportDisappearSetPositionAnimation : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject boss = GameObject.FindGameObjectWithTag(Tag.ENEMY);
        
        boss.GetComponent<LucipherController>().SetIsTeletransporting(true);

        Vector2 bossPosition = boss.transform.position;
        Vector2 newPosition = new Vector2(bossPosition.x, bossPosition.y + 2.80f);
        animator.GetComponent<Transform>().position = newPosition;

        boss.GetComponent<LucipherController>().DecreaseSpell(10f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
        
    // }

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
}
