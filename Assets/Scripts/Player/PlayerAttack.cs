using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackArea;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;


    private void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.swordSFX);
            Attack();
        }

      

        if (attacking)
        {
            timer += Time.deltaTime;
            
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }
    
    

    private void Attack()
    {
                    
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
