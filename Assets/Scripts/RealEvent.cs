using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class RealEvent : MonoBehaviour
{
    public Action<float> OnPlayerAttacked;
    public Action<IEnemy> OnEnemyKilled;

    public Action OnGamePaused;
    public Action OnGameUnpaused;

    public void GamePaused() { OnGamePaused?.Invoke(); }
    public void GameUnpaused() { OnGameUnpaused?.Invoke(); }

    public void PlayerAttacked(float damage) { OnPlayerAttacked?.Invoke(damage); }
    public void EnemyKilled(IEnemy enemy) { OnEnemyKilled?.Invoke(enemy); }


}
