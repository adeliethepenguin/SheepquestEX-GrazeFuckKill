using UnityEngine;

public class Hacker : MonoBehaviour, IEnemy
{
    public RealEvent EventManager { get; set; }
    public string EnemyName { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public string Name { get; set; }

    public float Range { get; set; }

    public Transform Trans { get; set; }

    public GameObject Player { get; set; }

    [SerializeField]
    public float setSpeed;
    public float rotationSpeed = 2f; 
    public float rotationAmount = 15f;

    [SerializeField]
    bool paused;
    public void Initialize(RealEvent events, GameObject player)
    {
        Speed = setSpeed;
        Player = player;
        EventManager = events;
        EventManager.OnGamePaused += Freeze;
        EventManager.OnGameUnpaused += Unfreeze;
        Name = "Hacker";
        Trans = this.transform;
    }
    private void OnDestroy()
    {
        Die();
        EventManager.OnGamePaused -= Freeze;
        EventManager.OnGameUnpaused -= Unfreeze;
    }

    public void Die()
    {
        EventManager.EnemyKilled(this);
    }

    private void Freeze()
    {
        paused = true;
    }

    private void Unfreeze()
    {
        paused = false;
    }

    public void Update()
    {
        if (!paused)
        {
            if (Player != null)
            {
                Vector3 directionToPlayer = Player.transform.position - Trans.position;
                
                Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
                Trans.rotation = Quaternion.Slerp(Trans.rotation, rotation, Time.deltaTime * Speed);
                float step = Speed * Time.deltaTime;
                Trans.position = Vector3.MoveTowards(Trans.position, Player.transform.position, step);
            }
            float zRotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        }
    }
    public void Attack()
    {

    }
}
