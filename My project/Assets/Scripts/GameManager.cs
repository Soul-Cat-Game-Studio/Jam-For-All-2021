using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private float _inputDelay = 5f;
    [SerializeField] private TweenFill _fill;

    [SerializeField] private UnityEvent timeOutEvent;



    private void Start()
    {
        _input.DisableAllInput();
        CoolDown();
        _fill.TriggerTween(_inputDelay);
    }

    private async void CoolDown()
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(_inputDelay), ignoreTimeScale: false);
        _input.SetCurrentMap(_input.gameControl.InGame);
        timeOutEvent?.Invoke();
    }


    private void OnDisable()
    {
        _input.DisableAllInput();
    }
}
