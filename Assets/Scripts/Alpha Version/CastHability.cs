using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastHability : MonoBehaviour
{
    public GameObject[] habilities;

    public void Cast(float direction, GameObject launchPoint, int habilityNumber){
        GameObject attack = Instantiate(habilities[habilityNumber], launchPoint.transform.position, Quaternion.identity);  
    }

}
