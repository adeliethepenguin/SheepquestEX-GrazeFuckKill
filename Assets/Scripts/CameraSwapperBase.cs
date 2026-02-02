using Unity.Cinemachine;
using UnityEngine;

public class CameraSwapperBase : MonoBehaviour
{
    public int shot = 0;

    public CinemachineCamera[] cams; 
    public Animator[] animators;

    public float timer =0f;
    public void CamUpdate()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot++;
                timer = 0f; 
            }
            else
            {
                if (shot > 0)
                {
                    shot--;
                }
            }
            for (int i = 0; i < cams.Length; i++)
            {
                if (i != shot)
                {
                    cams[i].enabled = false;
                }
                else
                {
                    cams[i].enabled = true;
                }
            }
            if (animators.Length > 0)
            {
                foreach (Animator anim in animators)
                {
                    anim.SetInteger("shot", shot);
                }
            }
        }
    }
}
