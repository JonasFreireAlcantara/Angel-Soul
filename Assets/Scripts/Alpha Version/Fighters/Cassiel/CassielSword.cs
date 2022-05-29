using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassielSword : MonoBehaviour
{
    public GameObject hitPrefab;

    void Start()
    {
        hitPrefab = GameObject.FindGameObjectWithTag(Tag.PLAYER).GetComponent<CassielController>().hitPrefab;
    }

    private bool isHitting = false;
    private bool isAttacking = true;
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.ENEMY)){
            if(!isHitting && isAttacking){
                isHitting = true;
                other.gameObject.GetComponent<FighterControllerBase>().DecreaseLife(15f);
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
