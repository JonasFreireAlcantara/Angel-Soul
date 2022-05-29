using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelFoot : MonoBehaviour
{
    public float amountOfDamage;

    public void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag(Tag.PLAYER))
        {
            CassielController player = collider2D.gameObject.GetComponent<CassielController>();
            player.DecreaseLife(amountOfDamage);
        }
    }
}
