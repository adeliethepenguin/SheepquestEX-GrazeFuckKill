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

    public bool paused;

    public float bulletSpeed = 10f;

    public TMP_Text bulletspeedtext;
    public Bulletscript bullet;
    public float baseBulletSpeed;

    public float minSizeMult;
    public float maxSizeMult;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        raybo = this.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f));

    }


    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            reticlePosition = this.transform.position;

            spin.x += Input.GetAxis("Mouse X");


            spin.y += Input.GetAxis("Mouse Y");
            spin.y = Mathf.Clamp(spin.y, -90, 90);

            transform.localRotation = Quaternion.Euler(-spin.y * speed, spin.x * speed, 0f);

            if (Input.GetMouseButton(0))
            {
                chargeTime += Time.deltaTime;
                float t = Mathf.Clamp01(chargeTime / maxPowChargeTime); 
                powerUp = Mathf.Lerp(0f, maxPower, t * t); 
                bulletspeedtext.text = "Current Bullet Charge: " + powerUp * 10f + "%!";
                Debug.Log("CHARGING AT " + powerUp + "%. GET READY TO FIRE!");
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (powerUp > 1f)
                {
                    Fire(bulletSpeed * powerUp, powerUp);
                    bulletspeedtext.text = "Last Bullet was fired at: " + powerUp * 10f + "% Power!";
                }
                else
                {
                    Fire(bulletSpeed, powerUp);
                    bulletspeedtext.text = "Last Bullet was fired at: " + powerUp * 10f + "% Power!";
                }
                powerUp = 0f;
                chargeTime = 0f;
            }
        }
    }

    void Fire(float speed, float power)
    {
        // Instantiate the bullet at the firePoint's position and rotation
        Bulletscript newBullet = Instantiate(bullet, transform.position, transform.rotation);

        // Get the Rigidbody component of the instantiated bullet (if it has one)
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if (power < 1f)
        {
            newBullet.health = 1f;
            newBullet.transform.localScale = newBullet.transform.localScale * minSizeMult;
        }
        else if (power<maxPower/2)
        {
            newBullet.health = 3f;
            newBullet.transform.localScale = newBullet.transform.localScale * ((minSizeMult+maxSizeMult)/2);
        }
        else
        {
            newBullet.health = 6f;
            newBullet.transform.localScale = newBullet.transform.localScale * maxSizeMult;
        }
        // Apply force to propel the bullet forward
        if (rb != null)
        {
            rb.linearVelocity = (transform.forward * (speed+baseBulletSpeed));
        }
    }
}
