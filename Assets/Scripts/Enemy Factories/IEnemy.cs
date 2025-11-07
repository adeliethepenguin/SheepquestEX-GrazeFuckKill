using UnityEngine;

public interface IEnemy
{
    public string EnemyName { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }

    public void Initialize();
}

