using UnityEngine;
using UnityEngine.InputSystem;

public class YouBigSheep : MonoBehaviour
{
    public FuckingBonusTime events;
    public float speed = 1f;
    public float sensitivity = 1f;

    private void RageModeACTIVATE()
    {
        float newSpeed = FuckingBonusTime.rageMeter % 20;
        if (newSpeed <= 1f)
        {
            speed = 1f;
        }
        else
        {
            speed = newSpeed;
        }
    }

    void Awake()
    {
        if (events != null)
        {
            events.RageUpdate += RageModeACTIVATE;
        }
    }

    void OnDestroy()
    {
        if (events != null)
        {
            events.RageUpdate -= RageModeACTIVATE;
        }
    }



    void Update()
    {
        
    }
}
