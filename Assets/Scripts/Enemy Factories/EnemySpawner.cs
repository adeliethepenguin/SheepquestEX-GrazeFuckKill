using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool canSpawn = true;

    

    public float spawnDelay;

    public RealEvent events;

    public NoobFactory noobFactory;
    public ProFactory proFactory;
    public HackerFactory hackerFactory;

    public int dimension;

    public int noobRate;
    public int proRate;
    public int hackRate;

    public GameObject player;

    [SerializeField]
    public List<IEnemy> enemies = new List<IEnemy>();

    public int maxEnemies = 5;

    public Transform[] spawnpoints;

    [SerializeField]
    bool paused = false;
    [SerializeField]
    int counter;

    private void Awake()
    {
        events.OnEnemyKilled += RemoveEnemy;
        events.OnGamePaused += PauseSpawning;
        events.OnGameUnpaused += ResumeSpawning;
        events.OnSceneSwitch += MakeDirty;
    }

    private void OnDestroy()
    {
        events.OnEnemyKilled -= RemoveEnemy;
        events.OnGamePaused -= PauseSpawning;
        events.OnGameUnpaused -= ResumeSpawning;
        events.OnSceneSwitch -= MakeDirty;
    }

    private void MakeDirty(int index)
    {
        Debug.Log("sceneswitch spawner");

        if (index == dimension)
        {

            foreach(IEnemy e in enemies) 
            {
                e.Dirty = false;
            }
            canSpawn = true;
        }
        else
        {
            foreach (IEnemy e in enemies)
            {
                e.Dirty = true;
            }
            canSpawn = false;
            
        }

        events.SceneReadied();
    }


    private void FixedUpdate()
    {
        if (!paused)
        {
            counter++;
            if (counter > spawnDelay)
            {
                SpawnEnemy();
                counter = 0;
            }
        }
    }

    private void PauseSpawning()
    {
        paused = true;
    }
    

    private void ResumeSpawning()
    {
        paused = false;
    }

    public void SpawnEnemy()
    {
            int currentEnemies = 0;
            if (enemies == null)
            {
                currentEnemies = 0;
            }
            else
            {
                currentEnemies = enemies.Count;
            }

            if (maxEnemies > currentEnemies)
            {
                int maxRate = noobRate + proRate + hackRate;
                int seed = Random.Range(0, maxRate);
                IEnemy newEnemy = null;
                if (seed < noobRate)
                {
                    Debug.Log("Noob Spawned");
                    newEnemy = noobFactory.CreateEnemy();
                }
                else if (seed < noobRate + proRate)
                {
                    Debug.Log("Pro Spawned");
                    newEnemy = proFactory.CreateEnemy();
                }
                else if (seed < maxRate)
                {
                    Debug.Log("Hacker Spawned");
                    newEnemy = hackerFactory.CreateEnemy();
                }
                if (newEnemy != null)
                {
                    newEnemy.Initialize(events, player);
                    newEnemy.Trans.position = spawnpoints[Random.Range(0, spawnpoints.Length)].position + newEnemy.Trans.position;
                    enemies.Add(newEnemy);
                    events.EnemySpawned(newEnemy);
                    if (!canSpawn)
                    {
                        newEnemy.Dirty = true;
                        events.SceneReadied();
                    }

                }
                else
                {
                    Debug.Log("FAIL!!!");
                }


            }
            else
            {
                Debug.Log("The Spawner by the name of: '" + transform.name + "' has Max Enemies! Enemy Not Spawned.");
            }
        
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        Debug.Log("Enemy ROmeved");
        enemies.Remove(enemy);
    }
}
