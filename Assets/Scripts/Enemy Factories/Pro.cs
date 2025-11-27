    using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pro : MonoBehaviour, IEnemy
    {
    public bool Dirty { get; set; }
    public RealEvent EventManager { get; set; }
        public string EnemyName { get; set; }
        
        public float Damage { get; set; }
        public float Speed { get; set; }

        public float Range { get; set; }
    public float Points {  get; set; }

        public string Name { get; set; }
        public Transform Trans { get; set; }

        public GameObject Player { get; set; }
    public float Health { get; set; }
    [SerializeField]
    public float setScore = 1f;
    public float setHealth;
    public GameObject Helmet;
    public GameObject HappyFace;
    public GameObject SadFace;
        bool paused;    
        public float setSpeed;
    
        public void Initialize(RealEvent events, GameObject player)
        {
        Points = setScore;
        Health = setHealth;
            Speed = setSpeed;
            Player = player;
            EventManager = events;
            EventManager.OnGamePaused += Freeze;
            EventManager.OnGameUnpaused += Unfreeze;
            Name = "Pro";
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
            if (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0));
            }
        }


        public void GetHit()
        {
            Health--;
            if (Health > 0)
            {
                Helmet.SetActive(false);
                HappyFace.SetActive(false);
                SadFace.SetActive(true);
            }

        else
        {
            Destroy(this.gameObject);
        }

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
