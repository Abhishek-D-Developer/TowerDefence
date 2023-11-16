using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewEnemy")]
public class EnemiesScriptableObject : ScriptableObject
{
    public string enemyName;
    public int health = 100;          // Set the health value
    public int firepower = 20;        // Set the firepower value
    public int speed = 2;
    public GameObject enemyPrefab;
}