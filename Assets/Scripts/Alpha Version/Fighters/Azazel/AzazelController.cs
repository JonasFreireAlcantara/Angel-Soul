using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelController : EnemyControllerBase
{
    public TornadoController tornadoController;

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
    }

    private void UpdateDistanceToPlayer()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        animator.SetFloat("distanceToPlayer", distance);
    }
}
