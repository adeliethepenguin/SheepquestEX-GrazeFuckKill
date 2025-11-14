using UnityEngine;

public interface IEnemy
{
    public RealEvent EventManager { get; set; }
    public string EnemyName { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public float Range { get; set; }

    public string Name { get; set; }

    public Transform Trans { get; set; }

    public GameObject Player { get; set;  }

    public void Initialize(RealEvent events, GameObject player);
    public void Die();
    public void Update();
    public void Attack();

}

