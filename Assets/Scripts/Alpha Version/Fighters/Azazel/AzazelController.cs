using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelController : EnemyControllerBase
{
    public TornadoController tornadoController;
    public float amountOfDamagePerFrame;

    // public void Awake()
    // {
    //     FindObjectOfType<AudioManager>().StopIntro("Fullmoon_intro");
    //     FindObjectOfType<AudioManager>().StopLoop("Fullmoon_loop");
    //     FindObjectOfType<AudioManager>().IntroPlay("Sensation_intro");
    //     FindObjectOfType<AudioManager>().LoopPlay("sensation_loop");
    // }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InitializeHealthAndSpellBars();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        UpdateDistanceToPlayer();

        RandomKickAttack();

        animator.SetFloat("spell", spell);
        IncreaseSpell(0.1f);
    }

    private void UpdateDistanceToPlayer()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        animator.SetFloat("distanceToPlayer", distance);
    }

    public void RandomKickAttack()
    {
        int value = Random.Range(0, 50);

        if (value == 1)
        {
            animator.SetTrigger("kickAttack");
        }
        // else
        // {
        //     animator.ResetTrigger("kickAttack");
        // }
    }

    public void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.PLAYER))
        {
            CassielController player = collision2D.gameObject.GetComponent<CassielController>();
            player.DecreaseLife(amountOfDamagePerFrame);
        }
    }

}
