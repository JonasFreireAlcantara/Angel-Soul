using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucipherController : EnemyControllerBase
{
    public RayController rayController;
    public Vector2 teletransportPosition1;
    public Vector2 teletransportPosition2;
    public Animator teletransportAnimator;
    private bool isTeletransporting = false;

    public void Awake()
    {
        FindObjectOfType<AudioManager>().StopIntro("Fullmoon_intro");
        FindObjectOfType<AudioManager>().StopLoop("Fullmoon_loop");
        FindObjectOfType<AudioManager>().IntroPlay("FINAL_STAGE_intro");
        FindObjectOfType<AudioManager>().LoopPlay("FINAL_STAGE_loop");
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InitializeHealthAndSpellBars();
        InitializeTeletransportPossiblePositions();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseSpell(0.2f);
        LookAtPlayer();
        UpdateDistanceToPlayer();

        animator.SetFloat("spell", spell);
        teletransportAnimator.SetFloat("spell", spell);
    }

    private void InitializeTeletransportPossiblePositions()
    {
        teletransportPosition1 = new Vector2(-6.34f, -3.57f);
        teletransportPosition2 = new Vector2(7.24f, -3.57f);
    }

    public void SetIsTeletransporting(bool value)
    {
        isTeletransporting = value;
        animator.SetBool("teletransporting", value);
    }

    public Vector2 GetNextTeletransportPosition()
    {
        float distance1 = Vector2.Distance(player.position, teletransportPosition1);
        float distance2 = Vector2.Distance(player.position, teletransportPosition2);

        if (distance1 > distance2)
        {
            return teletransportPosition1;
        }
        else
        {
            return teletransportPosition2;
        }
    }

    public void RandomAttackRay()
    {
        int value = Random.Range(0, 300);

        if (value == 1 && !isTeletransporting)
        {
            if (spell - 50f >= 0)
            {
                animator.SetTrigger("rayAttack");
                DecreaseSpell(50f);
            }
        }
    }

    private void UpdateDistanceToPlayer()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        teletransportAnimator.SetFloat("distanceToPlayer", distance);
    }

}
