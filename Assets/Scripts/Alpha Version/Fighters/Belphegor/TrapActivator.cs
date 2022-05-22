using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            GetComponentInParent<BelphegorHabilityOneAction>().Active();

            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
