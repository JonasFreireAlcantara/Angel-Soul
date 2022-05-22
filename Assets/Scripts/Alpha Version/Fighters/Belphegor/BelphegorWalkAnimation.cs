using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelphegorWalkAnimation : StateMachineBehaviour
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
        speed = animator.GetComponent<BelphegorController>().speed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Move();
       if(belphegorController.IsPlayerInsideAttackRange()){
           belphegorController.Attack();
       }
    }

    private void Move()
    {   
        float distance = Vector2.Distance(playerTransform.position, rigidbody2D.position);
        if(distance > 6f){
            Vector2 target = new Vector2(playerTransform.position.x, rigidbody2D.position.y);
            Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, belphegorController.speed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(newPosition);
        }
        else if (distance < 5f){
            Vector2 target = new Vector2(playerTransform.position.x, rigidbody2D.position.y);
            Vector2 newPosition = Vector2.MoveTowards(rigidbody2D.position, target, -1 * belphegorController.speed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(newPosition);
        }
        else{
            
        }
        
    }
}