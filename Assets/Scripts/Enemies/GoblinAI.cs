using UnityEngine;
using UnityEngine.AI;

public class GoblinAI : EnemeyAI
{

    [SerializeField] private float sightRange;
    private bool playerInSight;


    protected override void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position , sightRange, playerLayer);

        if (!playerInSight)
        {
            Patrol();
        }

        if (playerInSight)
        {
            Chase();
        }
        
    }
    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }
}
