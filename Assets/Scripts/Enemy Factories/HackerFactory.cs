using UnityEngine;

public class HackerFactory : EnemyFactory
{
    public Hacker hackerPrefab;

    public override IEnemy CreateEnemy()
    {
        Hacker hacker = Instantiate<Hacker>(hackerPrefab);
        return hacker;
    }
}
