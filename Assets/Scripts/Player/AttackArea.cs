using System;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Health>())
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
        
    }
}


