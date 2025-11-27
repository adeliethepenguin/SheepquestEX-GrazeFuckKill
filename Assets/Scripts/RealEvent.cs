using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class RealEvent : MonoBehaviour
{
    public Action<float> OnPlayerAttacked;


    public Action<IEnemy> OnEnemyKilled;
    public Action<int> OnSceneSwitch;
    public Action OnSceneInit;
    public Action OnGamePaused;
    public Action OnGameUnpaused;
    public Action<IEnemy> OnEnemySpawned;

    public void SceneSwitched(int newScene) { OnSceneSwitch?.Invoke(newScene); }
    public void SceneReadied() { OnSceneInit?.Invoke(); }

    public void GamePaused() { OnGamePaused?.Invoke(); }
    public void GameUnpaused() { OnGameUnpaused?.Invoke(); }

    public void PlayerAttacked(float damage) { OnPlayerAttacked?.Invoke(damage); }
    public void EnemyKilled(IEnemy enemy) { OnEnemyKilled?.Invoke(enemy); }

    public void EnemySpawned(IEnemy enemy) { OnEnemySpawned?.Invoke(enemy); }


}
