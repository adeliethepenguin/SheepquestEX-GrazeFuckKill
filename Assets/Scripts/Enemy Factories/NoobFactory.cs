using UnityEngine;

public class NoobFactory : EnemyFactory
{
    public Noob noobPrefab ;

    public override IEnemy CreateEnemy()
    {
        Noob noob = Instantiate<Noob>(noobPrefab);
        return noob;
    }

}
