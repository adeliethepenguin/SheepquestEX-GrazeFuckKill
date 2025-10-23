using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector2 spin;
    public Vector3 reticlePosition = Vector3.zero;
    public float speed;
    public Ray raybo;
    public float powerUp;
    public float powerMult = 1f;
    public float distance = 100f;
    public RaycastHit hitbo;

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
        
        transform.localRotation = Quaternion.Euler(-spin.y * speed, spin.x * speed, 0f);
        spin.y = Mathf.Clamp(spin.y, -90, 90);
        if (Input.GetMouseButton(0))
        {
            powerUp += Time.deltaTime * powerMult;
            Debug.Log("CHARGING AT " + powerUp + "%. GET READY TO FIRE!");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("YOU LET GO OF BUTTON");
            if (Physics.Raycast(reticlePosition, transform.forward, out hitbo, distance))
            {
                Debug.Log("YOU HIT A THING");
                if (hitbo.transform.tag == "Physics")
                {
                    Debug.Log("YOU HIT A THING I AM  APPLYING FORCE NOW.");
                    hitbo.rigidbody.AddForceAtPosition(transform.forward * powerUp, hitbo.point);
                }
            }
            powerUp = 0;
        }
    }
}
