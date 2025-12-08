using System;
using UnityEngine;

public class WitchAttack : MonoBehaviour
{
    public GameObject attack;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(attack, firePoint.position, firePoint.rotation);
    }
}
