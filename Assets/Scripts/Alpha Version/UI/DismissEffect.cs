using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismissEffect : MonoBehaviour
{   
    private float appearedTime;
    private float dismissTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        appearedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0){
            if(Time.time >= appearedTime + dismissTime){
                Dismiss();
            }
        }
    }
    private void Dismiss(){
        Destroy(this.gameObject);
    }
    public void SetTimeUntilDissmiss(float timeForDismiss){
        dismissTime = timeForDismiss;
    }
}
