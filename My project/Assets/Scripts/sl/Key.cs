using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Key : MonoBehaviour
{
    public UnityEvent finishEvent;   

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player")) finishEvent.Invoke();
    }
}
