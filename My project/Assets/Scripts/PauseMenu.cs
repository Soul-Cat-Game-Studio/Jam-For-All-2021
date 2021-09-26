using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PauseManager _pauseManager;

    [SerializeField] private RectTransform _pauseCanvas;

    public UnityEvent desactivate;

    private Tween _tween;

    private void OnEnable()
    {
        _input.PauseEvent += PauseInput;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= PauseInput;
    }

    private void Start()
    {
        _pauseManager.PlayGame();
    }

    private void PauseInput()
    {
        if (Time.timeScale == 0) PlayGame();
        else PauseGame();
    }

    public void PauseGame()
    {

        _pauseCanvas.gameObject.SetActive(true);
        _tween?.Kill();
        _tween = _pauseCanvas.DOScale(1, .4f).OnComplete(() => _pauseManager.PauseGame());
    }

    public void PlayGame()
    {
        desactivate?.Invoke();
        _pauseManager.PlayGame();
        _tween?.Kill();
        _tween = _pauseCanvas.DOScale(0, .4f).OnComplete(() => _pauseCanvas.gameObject.SetActive(false));
    }

}
