using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{   
    private float timeActivated;
    private void Start() {
        timeActivated = Time.time;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Update() {
        if(timeActivated + 1 <= Time.time){
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
}
