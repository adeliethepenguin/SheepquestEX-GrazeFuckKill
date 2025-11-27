using UnityEngine;

public class Noob : MonoBehaviour, IEnemy
{
    public bool Dirty { get; set; }
    public RealEvent EventManager { get; set; }
    public string EnemyName { get; set; }
    [SerializeField]
    public float Health { get; set; }
    public float Damage { get; set; }

    [SerializeField]
    public float setSpeed;
    public float setHealth;
    public float Speed { get; set; }

    public float Range { get; set; }

    public string Name { get; set; }

    public Transform Trans { get; set; }

    public GameObject Player { get; set; }

    public void GetHit()
    {
        Health--;
        if (Health <= 0)
        {

            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    bool paused = false;
    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        Die();
        EventManager.OnGamePaused -= Freeze;
        EventManager.OnGameUnpaused -= Unfreeze;
    }

    public void Initialize(RealEvent events, GameObject player)
    {
        Health = setHealth;
        Speed = setSpeed;
        Player = player;
        EventManager = events;
        EventManager.OnGamePaused += Freeze;
        EventManager.OnGameUnpaused += Unfreeze;
        Name = "Noob";
        Trans = this.transform;
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
                directionToPlayer.y = 0;
                Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
                Trans.rotation = Quaternion.Slerp(Trans.rotation, rotation, Time.deltaTime * Speed);
                float step = Speed * Time.deltaTime;
                Trans.position = Vector3.MoveTowards(Trans.position, Player.transform.position, step);
            }
        }
    }

    public void Attack()
    {

    }
}
