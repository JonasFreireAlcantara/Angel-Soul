using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelphegorHabilityOneAction : MonoBehaviour
{
    private float timeCasted;
    private bool actived = false;
    private float activationTime = 99999f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        timeCasted = Time.time;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0){
            if(timeCasted + 10f > Time.time){
                Dismiss();
            }
        }
    }

    void Dismiss(){
        if(!actived){
            Destroy(this.gameObject);
        }
        else if(Time.time >= activationTime + 1.2f){
            Destroy(this.gameObject);
        }
        
    }

    public void Active(){
        actived = true;

        animator.SetTrigger("active");

        activationTime = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            CassielController cc = other.gameObject.GetComponent<CassielController>();
            if(cc.isDefending){
                cc.DecreaseLife(10f);
            }
            else{
                cc.DecreaseLife(20f);
            }

            cc.Sleep(5f);
        }
    }
}
