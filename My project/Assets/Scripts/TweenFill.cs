using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TweenFill : MonoBehaviour
{
    [SerializeField] private Image image;

    public void TriggerTween(float secs)
    {
        DOTween.To(() => image.fillAmount, x => image.fillAmount = x, 0, secs);
    }
}
