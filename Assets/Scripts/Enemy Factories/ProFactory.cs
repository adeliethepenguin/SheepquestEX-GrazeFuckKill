using UnityEngine;

public class ProFactory : EnemyFactory
{
    public Pro proPrefab;

    public override IEnemy CreateEnemy()
    {
        Pro pro = Instantiate<Pro>(proPrefab);
        return pro;
    }
}
