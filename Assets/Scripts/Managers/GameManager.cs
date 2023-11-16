using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptables;
using ScriptableBullet;
using ScriptableObj;

public class GameManager : MonoBehaviour
{

    [SerializeField] EnemiesScriptableObjectList enemiesList;
    [SerializeField] Levels[] levels;
    [SerializeField] List<GameObject> enemiesSpawnedList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesList.enemiesList.Length; i++)
        {
            EnemyProperties enemyProperties = new EnemyProperties();
            enemyProperties.enemyName = enemiesList.enemiesList[i].name;
            enemyProperties.health = enemiesList.enemiesList[i].health;
            enemyProperties.speed = enemiesList.enemiesList[i].speed;
            enemyProperties.enemyPrefab = enemiesList.enemiesList[i].enemyPrefab;
            levels[0].waves[0].enemyProperties.Add(enemyProperties);
        }

        StartCoroutine(SpaawnEnemyWave());
    }

    IEnumerator SpaawnEnemyWave()
    {
        int size = levels[0].waves[0].enemyProperties.Count;
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(levels[0].waves[0].enemyProperties[i].enemyPrefab, transform);
            obj.GetComponent<EnemyMovement>().waypoints = levels[0].waves[0].wayPoints;
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Levels
{
    public Wave[] waves;
    public Transform[] wayPoints;
}

[System.Serializable]
public class Wave
{
    public bool strongEnemies;
    public Transform[] wayPoints;
    public List<EnemyProperties> enemyProperties = new List<EnemyProperties>();
}
[System.Serializable]
public class EnemyProperties
{
    public string enemyName;
    public int health;          // Set the health value
    public int firepower;        // Set the firepower value
    public int speed;             // Set the speed value
    public GameObject enemyPrefab;
}