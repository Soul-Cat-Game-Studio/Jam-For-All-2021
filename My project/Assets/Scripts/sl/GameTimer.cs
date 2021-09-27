using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public float TimeRemaining
    {
        get => _timeRemaining;

        set
        {
            _timeRemaining += value;
            if (_timeRemaining > 50) _timeRemaining = 50;
        }
    }

    private float _timeRemaining;

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Image _timeImage;

    public UnityEvent timeOut;



    private void Start()
    {
        _timeRemaining = 50;
        DOTween.To(() => _timeImage.fillAmount, x => _timeImage.fillAmount = x, 0, 50);
    }


    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
        }
        else
        {
            _timeRemaining = 0;
            timeOut?.Invoke();

        }

        var str = _timeRemaining.ToString("0") + "'";

        _timeText.text = str;



    }
}
