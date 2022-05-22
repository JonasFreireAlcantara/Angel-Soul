using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammomBaseAttackAction : MonoBehaviour
{
    private float timeCasted = -1;
    private float direction = 0f;

    void Start(){
        timeCasted = Time.time;
        bool flipped = GameObject.FindGameObjectWithTag(Tag.ENEMY).GetComponent<EnemyControllerBase>().isFlipped;
        if (flipped){
            direction = 1f;
        }
        else{
            direction = -1f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0){
            if(timeCasted + 1.5f <= Time.time){
                Dismiss();
            }
            Move();
        }
        
    }

    void Move(){
        Vector3 movement = new Vector3(direction, 0f, 0f);
        this.gameObject.transform.position += movement * Time.deltaTime * 5f;
    }

    void Dismiss(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(Tag.PLAYER)){
            Dismiss();
            
            if(other.gameObject.GetComponent<CassielController>().isDefending){
                other.gameObject.GetComponent<CassielController>().DecreaseLife(10f);
            }
            else {
                other.gameObject.GetComponent<CassielController>().DecreaseLife(30f);
            }

        }

    }
}
