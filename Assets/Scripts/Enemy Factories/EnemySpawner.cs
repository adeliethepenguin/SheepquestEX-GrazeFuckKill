using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EventStuff events;

    public EnemyFactory factory;

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
            IEnemy newEnemy = factory.CreateEnemy();
            newEnemy.Initialize(events);
            newEnemy.trans = spawnpoints[Random.Range(0, spawnpoints.Length - 1)];
            enemies.Add(newEnemy);
        }
        else
        {
            Debug.Log("MaxEnemies");
        }
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        enemies.Remove(enemy);
    }
}
