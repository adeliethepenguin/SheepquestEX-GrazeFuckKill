using UnityEngine;

public class Noob : MonoBehaviour, IEnemy
{
    public EventStuff EventManager { get; set; }
    public string EnemyName { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public float Range { get; set; }

    public Transform trans { get; set; }



    public void Initialize(EventStuff events)
    {
        EventManager = events;
    }


    public void Die()
    {
        EventManager.EnemyKilled(this);
    }

    public void Update()
    {

    }

    public void Attack()
    {

    }
}
