using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using System;

[CreateAssetMenu(fileName = "Turn Manager", menuName = "Board/TurnManager")]
public class TurnManager : ScriptableObject
{
    [SerializeField] private float turnTime;
    public event UnityAction PlayerTurnEvent = delegate { };
    public event UnityAction EnemyTurnEvent = delegate { };

    public async void NextTurn()
    {
        EnemyTurnEvent.Invoke();

        await UniTask.Delay(TimeSpan.FromSeconds(turnTime), ignoreTimeScale: false);

        PlayerTurnEvent.Invoke();
    }
}
