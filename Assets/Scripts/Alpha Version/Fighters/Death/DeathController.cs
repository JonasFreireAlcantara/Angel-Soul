using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : EnemyControllerBase
{
    public List<GameObject> deathSpellFires;
    public BlackHoleController blackHoleController;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InitializeHealthAndSpellBars();
    }

    void Update()
    {
        IncreaseSpell(0.025f);
        UpdateDistanceToPlayer();
    }

    private void UpdateDistanceToPlayer()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        animator.SetFloat("distanceToPlayer", distance);
    }

    public void RandomAttack()
    {
        int value = Random.Range(0, 900);

        if (value == 1)
        {
            DecreaseSpell(30f);
            if (spell >= 0)
            {
                animator.SetTrigger("attackFire");
            }
        }
        else if (value == 2)
        {
            DecreaseSpell(50);
            if (spell >= 0)
            {
                animator.SetTrigger("attackBall");
            }
        }
    }

}
