using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform enemyTransform;
    public Animator animator;
    public int framesToLive;
    public float speed;
    public float amountOfDamagePerFrame;

    private int initialFramesToLive;

    void Start()
    {
        initialFramesToLive = framesToLive;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardPlayer();
        framesToLive--;

        if (framesToLive <= 0)
        {
            animator.SetTrigger("finalizeTornado");
        }
    }

    public void Activate()
    {
        framesToLive = initialFramesToLive;
        transform.position = new Vector2(enemyTransform.position.x, enemyTransform.position.y + 2.8f);
        animator.SetTrigger("tornado");
        animator.ResetTrigger("finalizeTornado");
    }

    private void MoveTowardPlayer()
    {
        Vector2 target = new Vector2(playerTransform.position.x, transform.position.y);
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
