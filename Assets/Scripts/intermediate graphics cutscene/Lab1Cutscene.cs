using UnityEngine;

public class Lab1Cutscene : CameraSwapperBase
{
    public Transform oredBun;
    public Transform indooredBun;
    public Transform blurpleBun;

    public float walkSpeed = 1f;
    public float zoomLength = 5f;
    public float firstWalkLength = 5f;
    public float secondWalkLength = 5f;
    public float insidePullOutLength = 0.5f;
    

    

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        //Debug.Log(timer);
        CamUpdate();

        if (shot == 0)
        {
            if (timer < zoomLength)
            {
                if (timer > zoomLength / 60 * (120 - cams[0].Lens.FieldOfView + 1))
                {
                    cams[0].Lens.FieldOfView--;
                }
            }
            else if (timer < zoomLength + firstWalkLength)
            {
                oredBun.position += new Vector3(0, 0, -walkSpeed * Time.deltaTime);
            }

        }
        else if (shot == 1)
        {
            if (timer < secondWalkLength)
            {
                indooredBun.position += new Vector3(-walkSpeed * Time.deltaTime, 0, 0);
            }

        }
        if (shot == 3)
        {
            if (timer < insidePullOutLength)
            {
                Debug.Log("penis");
                if (timer > insidePullOutLength / 40 * (cams[3].Lens.FieldOfView-50))
                {
                    Debug.Log("balls");
                    cams[3].Lens.FieldOfView++;
                }
            }
        }
    }
}
