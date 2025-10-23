using UnityEngine;
using System;

public class FuckingBonusTime : MonoBehaviour
{
    
    public event Action RageUpdate;

    public void Enrage()
    {
        RageUpdate?.Invoke();
    }

    void Update()
    {
        
    }

    

    

}
