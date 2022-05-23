using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelphegorBaseAttackAction : MonoBehaviour
{
    private float timeAttacked;
    private float direction = 0;
    void Start(){
        timeAttacked = Time.time;
        bool flipped = GameObject.FindGameObjectWithTag(Tag.ENEMY).GetComponent<EnemyControllerBase>().isFlipped;
        if (flipped){
            direction = 1f;
        }
        else{
            direction = -1f;
        }
    }

    void Update(){
        if(Time.timeScale > 0){
            if(timeAttacked + 3f <= Time.time){
                Dismiss();
            }
            Move();
        }
    }

    void Move(){
        Vector3 movement = new Vector3(direction, 0f, 0f);
        this.gameObject.transform.position += movement * Time.deltaTime * 6f;
    }
    void Dismiss(){
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(Tag.PLAYER)){
            Dismiss();
            CassielController cc = other.gameObject.GetComponent<CassielController>();
            if(cc.isDefending){
                cc.DecreaseLife(5f);
            }
            else{
                cc.DecreaseLife(15f);
            }

            if(cc.isSleeping){
                cc.AwakeFromSleep();
            }
            
            
        }
    }
}
