using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{
    public Vector2 spin;
    public Vector3 reticlePosition = Vector3.zero;
    public float speed;
    public Ray raybo;
    public float powerUp;
    public float powerMult = 1f;
    public float distance = 100f;
    public float maxPowChargeTime = 2f;
    public float maxPower = 1000f;
    float chargeTime = 0f;
    public RaycastHit hitbo;

    public float bulletSpeed = 10f;
    public GameObject bullet;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        raybo = this.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f));

    }


    // Update is called once per frame
    void Update()
    {

        reticlePosition = this.transform.position;

        spin.x += Input.GetAxis("Mouse X");


        spin.y += Input.GetAxis("Mouse Y");
        spin.y = Mathf.Clamp(spin.y, -90, 90);

        transform.localRotation = Quaternion.Euler(-spin.y * speed, spin.x * speed, 0f);
        
        if (Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
            float t = Mathf.Clamp01(chargeTime / maxPowChargeTime); // takes 2s to fully charge
            powerUp = Mathf.Lerp(0f, maxPower, t * t); // quadratic growth
            Debug.Log("CHARGING AT " + powerUp + "%. GET READY TO FIRE!");
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (powerUp > 1f)
            {
                Fire(bulletSpeed * powerUp);
            }
            else
            {
                Fire(bulletSpeed);
            }
            powerUp = 0f;
            chargeTime = 0f;
        }
    }

    void Fire(float speed)
    {
        // Instantiate the bullet at the firePoint's position and rotation
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);

        // Get the Rigidbody component of the instantiated bullet (if it has one)
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        // Apply force to propel the bullet forward
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed;
        }
    }
}
