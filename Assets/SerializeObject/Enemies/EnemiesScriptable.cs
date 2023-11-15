using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewEnemy")]
public class EnemiesScriptableObject : ScriptableObject
{
    public string enemyName;
    public int health;
}