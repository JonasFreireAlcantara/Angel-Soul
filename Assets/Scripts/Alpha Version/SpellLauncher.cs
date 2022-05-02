using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLauncher : MonoBehaviour
{   
    public void Launch(GameObject spell, GameObject spellLaunchPoint, float direction){
        GameObject spellLaunched = Instantiate(spell, this.gameObject.transform.position, Quaternion.identity);

        spellLaunched.GetComponent<SpellOne>().launchTime = Time.time;
        spellLaunched.GetComponent<SpellOne>().direction = direction; 
    }
}
