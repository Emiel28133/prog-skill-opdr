using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnLocation;
    public List<GameObject> enemies = new List<GameObject>();

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnMultipleEnemies(100);
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClearEnemies();
        }
    }

    private void Start()
    {
     
        StartCoroutine(SpawnEnemiesOverTime());
    }

 
    private void SpawnMultipleEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnLocation.position, Quaternion.identity);
        enemies.Add(enemy);
    }


    private IEnumerator SpawnEnemiesOverTime()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(1f);
        }
    }


    private void ClearEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }
}
