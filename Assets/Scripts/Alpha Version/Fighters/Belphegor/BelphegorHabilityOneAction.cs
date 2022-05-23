using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelphegorHabilityOneAction : MonoBehaviour
{
    private float timeCasted;

    // Start is called before the first frame update
    void Start()
    {
        timeCasted = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0){
            if(timeCasted + 2f < Time.time){
                Dismiss();
            }
        }
    }

    void Dismiss(){
        Destroy(this.gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.PLAYER)){
            CassielController cc = other.gameObject.GetComponent<CassielController>();
            if(cc.isDefending){
                cc.DecreaseLife(5f);
            }
            else{
                cc.DecreaseLife(15f);
            }

            cc.Sleep(5f);
        }
    }
}
