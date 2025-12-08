using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    [SerializeField] private float speed = 1.5f;

    [SerializeField] private EnemyData data;

    private GameObject player;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetValues();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Health>() != null)
            {
                other.GetComponent<Health>().Damage(damage);
            }
        }
    }

    private void SetValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    
}
