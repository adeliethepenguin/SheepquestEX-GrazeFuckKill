using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class SidonCutscene : MonoBehaviour
{
    public int shot = 0;
    public CinemachineCamera[] cams;

    public float establishspeed = 2;
    public float establishtime = 5;

    public float jumpHor = 2;
    public float jumpVert = 1.5f;

    public float dramaticPause = 2;
    public float lookUpAtTime = 3;

    public Animator sidon;

    public Transform[] locations;

    float timer = 0f;
    bool balls  = false;
    private void Update()
    {
        timer += Time.deltaTime;
        if (shot == 0)
        {
            if (timer < establishtime)
            {
                cams[0].transform.position += Vector3.forward * establishspeed * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shot += 1;
            sidon.SetInteger("shot", shot);
            timer = 0f;
            for (int i = 0; i < cams.Length; i++)
            {

                if (i != shot)
                {
                    if (cams[i] != null)
                    {
                        cams[i].gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (cams[i] != null)
                    {
                        cams[i].gameObject.SetActive(true);
                    }
                }
            }

        }
        switch (shot) {
            case 2:
            if (timer < jumpHor)
                {
                    sidon.transform.position += Vector3.forward * establishspeed * Time.deltaTime;
                    cams[2].transform.position += Vector3.forward * -establishspeed * Time.deltaTime;
                }
            else if (timer < jumpHor + jumpVert)
            {
                    cams[2].transform.Rotate(Vector3.right * 10 * Time.deltaTime, Space.Self);
                    sidon.transform.position += Vector3.down * establishspeed * Time.deltaTime;
            }
                break;
            case 3:
                
                if (!balls)
                {
                    sidon.transform.position = locations[0].position;
                    balls = true;
                }
                if (timer < dramaticPause)
                {
                    // hi
                }
                else if(timer < lookUpAtTime + dramaticPause)
                {
                        cams[3].transform.Rotate(Vector3.left * 10 * Time.deltaTime, Space.Self);
                }
                else
                {
                    sidon.SetBool("Dude", true);
                }
                    break;
            default:
                break;
    }
    }
}
