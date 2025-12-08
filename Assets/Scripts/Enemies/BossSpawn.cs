using System;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss;
    public GameObject Portal;


    private void Update()
    {
        
        if (boss.IsDestroyed())
        {
            Portal.SetActive(true);
        }
        
    }

    
    
}
