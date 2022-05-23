using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public float amountOfDamagePerFrame = 10f;

    public void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag(Tag.PLAYER))
        {
            CassielController player = collider2D.gameObject.GetComponent<CassielController>();
            player.DecreaseLife(amountOfDamagePerFrame);
        }
    }
}
