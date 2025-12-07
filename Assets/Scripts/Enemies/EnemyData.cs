using UnityEngine;

// Creates a new object that can be created for Enemies
[CreateAssetMenu(fileName = "Data", menuName = "EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
   public int hp;
   public int damage;
   public float speed;


}
