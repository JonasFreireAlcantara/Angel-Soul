using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelStaff : MonoBehaviour
{
    private bool isHitting = false;
    private bool isAttacking = true;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            if(!isHitting && isAttacking){
                Debug.Log("Hit");
                isHitting = true;
                other.gameObject.GetComponent<FighterControllerBase>().DecreaseLife(30f);
            }
           
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        isHitting = false;
        isAttacking = false;
    }

    public void setAttacking(bool state){
        isAttacking = state;
    }
}
