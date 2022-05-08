using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamonWalkAnimation : StateMachineBehaviour
{
   private Transform playerTransform;
   private Rigidbody2D rigidbody2D;
   private MamonController mamonController;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      rigidbody2D = animator.GetComponent<Rigidbody2D>();
      mamonController = animator.GetComponent<MamonController>();
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      WalkTowardPlayer();

      if (mamonController.IsPlayerInsideSwordAttackRange())
      {
         mamonController.SwordAttack();
      }
   }

   private void WalkTowardPlayer()
   {
      Vector2 target = new Vector2(playerTransform.position.x, rigidbody2D.position.y);
      Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, mamonController.speed * Time.fixedDeltaTime);
      rigidbody2D.MovePosition(newPosition);
   }

}
