using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathStandUpOneArmAnimation : StateMachineBehaviour
{

    private DeathController deathController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deathController = animator.GetComponent<DeathController>();
        List<GameObject> deathSpellFires = deathController.deathSpellFires;

        ActivateSpellFiresRandomly(deathSpellFires, 8);
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

    private void ActivateSpellFiresRandomly(List<GameObject> spellFires, int amount)
    {
        Shuffle(spellFires);

        for (int i = 0; i < amount; i++)
        {
            spellFires[i].SetActive(true);
        }
    }

    private void Shuffle(List<GameObject> list)  
    {
        System.Random rng = new System.Random();
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            GameObject value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

}
