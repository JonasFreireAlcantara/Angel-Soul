using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassielSword : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.ENEMY)){
            other.GetComponent<FighterControllerBase>().DecreaseLife(10f);
        }
    }
}
