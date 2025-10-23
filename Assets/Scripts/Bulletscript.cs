using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public AudioSource killsound;
    public float lifetime = 3.0f;
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
                killsound.Play();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);

            
        }
    }
}
