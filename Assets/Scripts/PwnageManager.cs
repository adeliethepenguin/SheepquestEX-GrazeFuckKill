using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PwnageManager : Singleton
{
    public static float hornyMeter;
    public static float rageMeter = 0f;

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
            rageMeter += (hornyMeter / 100f);
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
       rageMeter += 1f;
    }
    void ShallWeGetHorny()
    {
        Debug.Log("i love my wife");
    }
}
