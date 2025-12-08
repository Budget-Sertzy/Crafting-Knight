using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    void Start()
    {
        
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Damage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment")) 
        {
            Destroy(gameObject);
        }
    }
}
