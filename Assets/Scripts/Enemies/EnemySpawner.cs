using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;
   
   [SerializeField] private float spawnInterval = 3.5f;

   private void Start()
   {
      StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
   }

  

   private IEnumerator spawnEnemy(float interval, GameObject enemy)
   {
      yield return new WaitForSeconds(interval);
      GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, -6f), 0),
         Quaternion.identity);
      StartCoroutine(spawnEnemy(interval, enemy));
   }
}
