using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class EventStuff : MonoBehaviour
{
    public Action<float> OnPlayerAttacked;
    public Action<IEnemy> OnEnemyKilled;

    public void PlayerAttacked(float damage) { OnPlayerAttacked?.Invoke(damage); }
    public void EnemyKilled(IEnemy enemy) { OnEnemyKilled?.Invoke(enemy); }
    

}
