using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public AudioSource killsound;
    public float lifetime = 3.0f;
    public float health = 1f;
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (killsound != null)
            {
                Debug.Log("attempting to set pitch to: " + (1f + (health * 0.3f)));
                killsound.pitch =1f+(health*0.3f);
                Debug.Log(killsound.pitch);
                killsound.Play();
            }
            Destroy(other.gameObject);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
