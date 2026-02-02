using UnityEngine;
using Unity.Cinemachine;

public class quickPan : MonoBehaviour
{
    public CinemachineCamera cam1;
    public CinemachineCamera cam2;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }
    }
}
