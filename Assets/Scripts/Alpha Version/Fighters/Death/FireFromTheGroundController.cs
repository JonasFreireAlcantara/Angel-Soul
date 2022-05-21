using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFromTheGroundController : MonoBehaviour
{
    public int framesToLive = 250;

    public void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag(Tag.PLAYER))
        {
            CassielController player = collider2D.gameObject.GetComponent<CassielController>();
            player.DecreaseLife(0.5f);
            
        }
    }

    public void Update()
    {
        if (framesToLive <= 0)
        {
            gameObject.SetActive(false);
        }

        framesToLive -= 1;
    }

    public void Activate()
    {
        framesToLive = 250;
        gameObject.SetActive(true);
    }


}
