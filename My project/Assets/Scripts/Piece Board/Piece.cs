using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour
{
    [Header("Start")]
    [SerializeField] private Node _startNode;
    [SerializeField] private float _startPlaceSpeed;

    [Space(20)]

    [Header("Configuration")]
    public float walkSpeed;
    public float turnSpeed;

    private Node _currentNode;
    private Tween _moveTween;
    private Tween _rotTween;
    private Direction _currentDiretion;

    private void Start()
    {
        _currentNode = _startNode;
        _moveTween = transform.DOMove(_currentNode.transform.position, _startPlaceSpeed);
    }

    public virtual void Move(Direction direction)
    {
        foreach (var item in _currentNode.nodeDirections)
        {
            if (direction == item.direction)
            {
                _moveTween = transform.DOMove(item.node.transform.position, walkSpeed);

                _currentNode = item.node;
            }
        }

    }
}
