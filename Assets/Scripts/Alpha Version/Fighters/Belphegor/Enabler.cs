using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            GameObject.FindGameObjectWithTag(Tag.ENEMY).GetComponent<BelphegorController>().playerLanded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            GameObject.FindGameObjectWithTag(Tag.ENEMY).GetComponent<BelphegorController>().playerLanded = false;
        }
    }
}
