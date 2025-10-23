using TMPro;
using UnityEngine;

public class PwnageManager : Singleton
{
    public static float hornyMeter;
    public static float rageMeter = 0f;
    public static float rageRate = 0.1f;

    public float rageMax = 2000f;

    public TextMeshPro hornytext;
    public TextMeshPro ragetext;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            UpdateStats();
        }
    }

    void UpdateStats()
    {
        if (hornyMeter < 100f)
        {
            hornyMeter += 0.1f;
            if (hornyMeter > 100f)
            {
                hornyMeter = 100f;
            }
        }
        if (rageMeter < rageMax)
        {
            rageMeter += (hornyMeter / 10f);
            if (rageMeter > rageMax)
            {
                rageMeter = rageMax;
            }
        }


    }

    void FixedUpdate()
    {
        ShallWeGetHorny();
    }

    void ShallWeRage()
    {
        int i = UnityEngine.Random.Range(1, 100);
        if (i <= rageRate * 100)
        {
            rageMeter += 1f;
            //RageUpdate?.Invoke();
        }
    }
    void ShallWeGetHorny()
    {
        Debug.Log("i love my wife");
    }
}
