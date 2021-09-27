using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using System;

[CreateAssetMenu(fileName = "Turn Manager", menuName = "Board/TurnManager")]
public class TurnManager : ScriptableObject
{
    [SerializeField] private float _enemyTurnTime;
    [SerializeField] private float _playerTurnTime;
    public event UnityAction PlayerTurnEvent = delegate { };
    public event UnityAction EnemyTurnEvent = delegate { };

    public void StartGame() => PlayerTurnEvent.Invoke();

    public async void NextTurn()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_enemyTurnTime), ignoreTimeScale: false);

        EnemyTurnEvent.Invoke();

        await UniTask.Delay(TimeSpan.FromSeconds(_playerTurnTime), ignoreTimeScale: false);

        PlayerTurnEvent.Invoke();
    }
}
