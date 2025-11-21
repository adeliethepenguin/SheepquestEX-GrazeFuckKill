using System.Collections.Generic;
using UnityEngine;

public class FlagMan : MonoBehaviour
{

    public RealEvent events;

    public List<IEnemy> enemies = new List<IEnemy>();

    public void Awake()
    {
        
        events.OnSceneInit += LoadTimeYayyyy;
        events.OnEnemySpawned += AddEnemy;
        events.OnEnemyKilled += RemoveEnemy;
    }

    private void OnDestroy()
    {
        events.OnSceneInit -= LoadTimeYayyyy;
        events.OnEnemySpawned -= AddEnemy;
        events.OnEnemyKilled -= RemoveEnemy;
    }

    private void AddEnemy(IEnemy enemy)
    {
        enemies.Add(enemy);
    }
    private void RemoveEnemy(IEnemy enemy)
    {
        enemies.Remove(enemy);
    }


    
    
    private void LoadTimeYayyyy() 
        // this is called during the RealEvent's SceneReadied() function
        // which is called through the EnemySpawner AFTER the EnemySpawner marks them as Dirty.
    {
        foreach(MonoBehaviour e in enemies)
        {
            if (e.GetComponent<IEnemy>().Dirty)
            {
                e.gameObject.SetActive(false);
                
                
            }
            else
            {
                e.gameObject.SetActive(true);
                
            }
        }
    }


}
