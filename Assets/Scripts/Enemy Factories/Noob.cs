using UnityEngine;

public class Noob : MonoBehaviour, IEnemy
{
    public EventStuff EventManager { get; set; }
    public string EnemyName { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public float Range { get; set; }

    public string Name { get; set; }

    public Transform Trans { get; set; }

    public GameObject Player { get; set; }

    public void Initialize(EventStuff events, GameObject player)
    {
        EventManager = events;
        Name = "Noob";
        Trans = this.transform;
    }


    public void Die()
    {
        EventManager.EnemyKilled(this);
    }

    public void Update()
    {
        if (Player != null)
        {
            Vector3 directionToPlayer = Player.transform.position - Trans.position;
            directionToPlayer.y = 0;
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
            Trans.rotation = Quaternion.Slerp(Trans.rotation, rotation, Time.deltaTime * Speed);

            
            float step = Speed * Time.deltaTime;
            Trans.position = Vector3.MoveTowards(Trans.position, Player.transform.position, step);
        }
    }

    public void Attack()
    {

    }
}
