using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassielSword : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.ENEMY)){
            other.gameObject.GetComponent<FighterControllerBase>().DecreaseLife(10f);
        }
    }
}
