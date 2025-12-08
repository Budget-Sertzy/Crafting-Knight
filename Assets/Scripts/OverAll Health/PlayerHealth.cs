using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    [SerializeField] GameObject currentGameObject = default;

    private int maxHealth = 100;
    

    public HealthBar HealthBar;


    private void Start()
    {
        HealthBar.SetMaxHealth(maxHealth);
        
    }

    void Update()
    {
        // HealthBar.SetHealth(health); for  changing the healthbar
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No Negative Damage");
        }
        
        this.health -= amount;
        HealthBar.SetHealth(health);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.hitSFX);

        if (health < -0)
        {
            die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("No Negative Healing");
        }

        if (health + amount > maxHealth)
        {
            this.health = maxHealth;
            HealthBar.SetHealth(health);
        }
        else
        {
            this.health += amount;   
            HealthBar.SetHealth(health);
        }
        
    }

    public void die()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.gameoverSFX);
        Destroy(gameObject);
        
        Debug.Log("This Object as died");
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.maxHealth = maxHealth;
        this.health = health;
    }
}