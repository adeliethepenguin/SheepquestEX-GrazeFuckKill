using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public AudioSource killsound;
    public float lifetime = 3.0f;
    public float health = 1f;
    private bool yeah = false;
    public float maxHealth;

    bool dead = false;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!yeah)
        {
            maxHealth = health;
            yeah = true;
        }
        if (other.transform.tag == "Enemy")
        {
            if (killsound != null)
            {
                Debug.Log("attempting to set pitch to: " + ( 1f - ((health - maxHealth) * 0.08f)));
                killsound.pitch =1f-((health-maxHealth)*0.08f);
                Debug.Log(killsound.pitch);
                killsound.Play();
            }
            other.gameObject.GetComponent<IEnemy>().GetHit();
            health--;
            if (health <= 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                Destroy(gameObject, killsound.clip.length);
            }
            
        }
    }
}
