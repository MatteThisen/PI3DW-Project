using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{

    public List<GameObject> enemyPrefabs = new List<GameObject>();
    private List<GameObject> enemiesInScene = new List<GameObject>();
    private GameObject enemyPrefab;
    private Vector3 spawnPosition = new Vector3(0, 0, 0);
    private NavMeshHit hit;
    public int yourNavMeshLayer = 6;
    private int enemyAmount = 1;


    Vector3 EnemySpawnPosition()
    {
        int x, y, z;
        x = Random.Range(-100, 100);
        y = Random.Range(0, 100);
        z = Random.Range(-100, 100);
        return new Vector3(x, y, z);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogError("Enemies list is empty!");
            return;
        }

        SpawnEnemy();

    }

    public void EnemyDeath(GameObject enemy)
    {
        enemiesInScene.Remove(enemy);
        enemy.GetComponent<AIEnemy>().enabled = false;
        enemy.GetComponent<NavMeshAgent>().enabled = false;
        enemy.GetComponent<Animator>().enabled = false;

        if (enemiesInScene.Count != 0)
        {
            Debug.LogError("Not spawning new enemies; Enemies are still here!");
            Debug.Log("Enemy Count: " + enemiesInScene.Count);
            Debug.Log(enemiesInScene);
            return;
        }

        SpawnEnemy();
    }

    // Spawns an enemy at a random position on the NavMesh. Each time this method is called, the enemyAmount is incremented by 1, meaning that one more enemy will be spawned for each call.
    public void SpawnEnemy()
    {

        for (int i = 0; i < enemyAmount; i++)
        {
            enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            if (enemyPrefab == null)
            {
                Debug.LogError("Selected enemy prefab is null!");
                return;
            }

            spawnPosition = EnemySpawnPosition();
            Debug.Log($"Spawn Position: {spawnPosition}");

            if (NavMesh.SamplePosition(spawnPosition, out hit, 1000, NavMesh.AllAreas))
            {
                var correctedSpawnPosition = hit.position;
                Debug.Log($"Corrected Spawn Position: {correctedSpawnPosition}");
                enemiesInScene.Add(Instantiate(enemyPrefab, correctedSpawnPosition, Quaternion.identity));
            }
            else
            {
                Debug.LogError("Failed to find a valid NavMesh position!");
            }
        }

        enemyAmount++;

    }

}