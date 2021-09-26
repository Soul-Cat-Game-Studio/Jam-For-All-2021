using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour
{
    [SerializeField] protected TurnManager _turnManager;

    [Header("Start")]
    [SerializeField] protected Node _startNode;
    [SerializeField] protected float _startPlaceSpeed;

    [Space(20)]

    [Header("Configuration")]
    public float walkSpeed;
    public float turnSpeed;

    protected Node _currentNode;
    protected Tween _moveTween;
    protected Tween _rotTween;
    protected Direction _currentDiretion;

    public virtual void OnEnable()
    {
        _turnManager.PlayerTurnEvent += StartPlayerTurn;
        _turnManager.EnemyTurnEvent += StartEnemyTurn;
    }

    public virtual void OnDisable()
    {
        _turnManager.PlayerTurnEvent -= StartPlayerTurn;
        _turnManager.EnemyTurnEvent -= StartEnemyTurn;
    }

    private void Start()
    {
        _currentNode = _startNode;
        _moveTween = transform.DOMove(_currentNode.transform.position, _startPlaceSpeed);
    }

    public virtual void StartPlayerTurn() { }
    public virtual void StartEnemyTurn() { }

    public virtual void Move(Direction direction)
    {
        foreach (var item in _currentNode.nodeDirections)
        {
            if (direction == item.direction)
            {
                _moveTween = transform.DOMove(item.node.transform.position, walkSpeed);
                RotateBody(direction);
                _currentNode = item.node;
            }
        }
    }

    private void RotateBody(Direction direction)
    {
        var rot = Vector3.zero;

        switch (direction)
        {
            case Direction.Foward:
                rot = new Vector3(0, 0, 0);
                _rotTween = transform.DOLocalRotate(rot, turnSpeed);
                break;

            case Direction.Rigth:
                rot = new Vector3(0, 90, 0);
                _rotTween = transform.DOLocalRotate(rot, turnSpeed);
                break;

            case Direction.Backwarrd:
                rot = new Vector3(0, 180, 0);
                _rotTween = transform.DOLocalRotate(rot, turnSpeed);
                break;
            case Direction.Left:
                rot = new Vector3(0, 260, 0);
                _rotTween = transform.DOLocalRotate(rot, turnSpeed);
                break;
        }
    }
}
