using UnityEngine;
using UnityEngine.AI;

public class GoblinAI : EnemeyAI
{

    [SerializeField] private float sightRange;
    
    private bool playerInSight;

    [SerializeField] private Animator moving;

    protected override void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position , sightRange, playerLayer);

        if (!playerInSight)
        {
            moving.SetBool("Moving" , false);
            Patrol();
        }

        if (playerInSight)
        {
            moving.SetBool("Moving" , true);
            Chase();
        }
        
    }
    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }
}
