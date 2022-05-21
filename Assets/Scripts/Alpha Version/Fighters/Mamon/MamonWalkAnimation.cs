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
      playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
      rigidbody2D = animator.GetComponent<Rigidbody2D>();
      mamonController = animator.GetComponent<MamonController>();
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(OutOfDistance())
         WalkTowardPlayer();

      if (mamonController.IsPlayerInsideAttackRange())
      {
         mamonController.SwordAttack();
      }
   }

   private void WalkTowardPlayer()
   {
      if(Vector2.Distance(playerTransform.position, rigidbody2D.position) > 2.5f){
         Vector2 target = new Vector2(playerTransform.position.x, rigidbody2D.position.y);
         Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, mamonController.speed * Time.fixedDeltaTime);
         rigidbody2D.MovePosition(newPosition);
      }
      
   }

   private bool OutOfDistance(){
      return Vector2.Distance(playerTransform.position, rigidbody2D.position) > 2.5f ? true : false;
   }

}
