using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotateTween : MonoBehaviour
{
    public Vector3 rotateOffset;
    public Transform target;
    public float timeRotate;

    public void Rotate()
    {
        target.DOLocalRotate(rotateOffset, timeRotate);
    }
}