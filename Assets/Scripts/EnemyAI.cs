using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemeyAI : MonoBehaviour
{
    protected GameObject player;

    protected NavMeshAgent agent;

    [SerializeField] protected LayerMask groundLayer, playerLayer;

    protected Vector3 destPoint;
    protected bool walkpointSet;
    [SerializeField] protected float range;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        
    }

    protected virtual void Update()
    {
        Patrol();
    }

    protected void Patrol()
    {
        if(!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    protected void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
