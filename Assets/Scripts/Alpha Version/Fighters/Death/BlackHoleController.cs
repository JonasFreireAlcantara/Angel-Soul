using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    public float speed;
    public float amountOfDamagePerFrame = 0.5f;

    private Transform playerTransform;
    private Transform enemyTransform;
    private int framesToLive = 500;

    // Update is called once per frame
    void Update()
    {
        FloatTowardPlayer();
        framesToLive--;

        if (framesToLive <= 0)
        {
            framesToLive = 500;
            gameObject.SetActive(false);
        }
    }

    public void Activate()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        enemyTransform = GameObject.FindGameObjectWithTag(Tag.ENEMY).transform;
        framesToLive = 500;
        transform.position = enemyTransform.position;
        gameObject.SetActive(true);
    }

    private void FloatTowardPlayer()
    {
        Vector2 target = playerTransform.position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }

    public void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag(Tag.PLAYER))
        {
            CassielController player = collider2D.gameObject.GetComponent<CassielController>();
            player.DecreaseLife(amountOfDamagePerFrame);
        }
    }
}
