using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EventStuff events;

    public NoobFactory noobFactory;
    public ProFactory proFactory;

    public int noobRate;
    public int proRate;
    public int hackRate;

    public GameObject player;

    public List<IEnemy> enemies;

    public int maxEnemies = 5;

    public Transform[] spawnpoints;

    private void Awake()
    {
        events.OnEnemyKilled += RemoveEnemy;
    }

    private void OnDestroy()
    {
        events.OnEnemyKilled -= RemoveEnemy;
    }

    public void SpawnEnemy()
    {
        

        if (maxEnemies > enemies.Count)
        {
            int maxRate = noobRate + proRate + hackRate;
            int seed = Random.Range(1, maxRate);

            if (seed <= noobRate)
            {
                Debug.Log("Noob Spawned");
                IEnemy newEnemy = noobFactory.CreateEnemy();
                newEnemy.Initialize(events, player);
                newEnemy.Trans = spawnpoints[Random.Range(0, spawnpoints.Length - 1)];
                enemies.Add(newEnemy);
            }
            else if (seed <= noobRate + proRate)
            {
                Debug.Log("Pro Spawned");
                IEnemy newEnemy = proFactory.CreateEnemy();
                newEnemy.Initialize(events, player);
                newEnemy.Trans = spawnpoints[Random.Range(0, spawnpoints.Length - 1)];
                enemies.Add(newEnemy);
            }
            else if (seed <= maxRate)
            {

            }

            
        }
        else
        {
            Debug.Log("Max Enemies! Enemy Not Spawned.");
        }
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        enemies.Remove(enemy);
    }
}
