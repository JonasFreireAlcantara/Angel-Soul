using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassielSword : MonoBehaviour
{
    private bool isHitting = false;
    private bool isAttacking = true;
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.ENEMY)){
            if(!isHitting && isAttacking){
                isHitting = true;
                other.gameObject.GetComponent<FighterControllerBase>().DecreaseLife(10f);
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
