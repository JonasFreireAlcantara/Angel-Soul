using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOne : MonoBehaviour
{   
    public float direction = 0;
    public float launchTime = -1;
    public float spellDamage = 10;

    private void Update() {
        
        if(direction != 0)
            Move();
        
        Dismiss();
   
    }

    private void Move(){
        Vector3 movement = new Vector3(direction, 0f, 0f);
        this.gameObject.transform.position += movement * Time.deltaTime * 13.5f;
    }

    private void Dismiss(){
        if(Time.time > launchTime + 2f){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.ENEMY)){
            Destroy(this.gameObject);
        }

    }
}
