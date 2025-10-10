using UnityEngine;
using System;

public class FuckingBonusTime : MonoBehaviour
{
    public static float rageMeter = 0f;
    public static float rageRate = 0.1f;

    public static float hornyMeter;

    public event Action RageUpdate;

    public void Enrage()
    {
        RageUpdate?.Invoke();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ShallWeRage();
        ShallWeGetHorny();
    }

    void ShallWeRage()
    {
        int i = UnityEngine.Random.Range(1, 100);
        if (i <= rageRate * 100)
        {
            rageMeter += 1f;
            RageUpdate?.Invoke();
        }
    }

    void ShallWeGetHorny()
    {
        Debug.Log("i love my wife");
    }
}
