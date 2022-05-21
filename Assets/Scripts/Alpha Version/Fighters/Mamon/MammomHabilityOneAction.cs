using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammomHabilityOneAction : MonoBehaviour
{   
    private float timeCasted = -1;

    // Start is called before the first frame update
    void Start(){
        timeCasted = Time.time;
        bool flipped = GameObject.FindGameObjectWithTag(Tag.ENEMY).GetComponent<EnemyControllerBase>().isFlipped;
        if (flipped){
            this.gameObject.transform.Rotate(0f,180f,0f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0){
            if(timeCasted + 1.5f <= Time.time){
                Dismiss();
            }
        }
        
    }

    void Dismiss(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(Tag.PLAYER)){
            CassielController controller = other.gameObject.GetComponent<CassielController>();
            controller.DecreaseLife(30f);
            GameObject.FindGameObjectWithTag(Tag.ENEMY).GetComponent<MamonController>().SpellVamp(15f, 0f);
        }

    }

}
