using UnityEngine;

public interface IEnemy
{
    public EventStuff EventManager { get; set; }
    public string EnemyName { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public float Range { get; set; }

    public Transform trans { get; set; }



    public void Initialize(EventStuff events);
    public void Die();
    public void Update();
    public void Attack();

}

