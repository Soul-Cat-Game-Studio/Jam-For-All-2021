using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour
{
    [SerializeField] protected TurnManager _turnManager;

    [Header("Start")]
    [SerializeField] protected Node _startNode;
    [SerializeField] protected Direction _startDirection;

    [SerializeField] protected float _startPlaceSpeed;

    [Space(20)]

    [Header("Configuration")]
    public float walkSpeed;
    public float turnSpeed;

    public PieceType pieceType;


    protected Node _currentNode;
    protected Direction _currentDirection;

    protected Tween _moveTween;
    protected Tween _rotTween;


    protected virtual void OnEnable()
    {
        _turnManager.PlayerTurnEvent += StartPlayerTurn;
        _turnManager.EnemyTurnEvent += StartEnemyTurn;
    }

    protected virtual void OnDisable()
    {
        _turnManager.PlayerTurnEvent -= StartPlayerTurn;
        _turnManager.EnemyTurnEvent -= StartEnemyTurn;
    }

    protected virtual void Start()
    {
        _currentDirection = _startDirection;
        _currentNode = _startNode;
        _currentNode.EnterPiece(this, pieceType);

        _moveTween = transform.DOMove(_currentNode.transform.position, _startPlaceSpeed);
        RotateBody(_currentDirection);
    }

    public virtual void Died()
    {
        _turnManager.PlayerTurnEvent -= StartPlayerTurn;
        _turnManager.EnemyTurnEvent -= StartEnemyTurn;

        var sequence = DOTween.Sequence();
        sequence.Pause();
        sequence.SetAutoKill(false);

        sequence
        .Append(transform.DORotate(new Vector3(0, 0, 90), .4f))
        .Append(transform.DOMoveY(10, .4f).OnComplete(() => gameObject.SetActive(false)));
        sequence.Play();
    }

    public virtual void StartPlayerTurn() { }
    public virtual void StartEnemyTurn() { }

    protected virtual void Move(Direction direction)
    {
        Node nextNode = NextNodeDirection(direction);
        if (nextNode == null) return;

        _currentNode.ExitPiece(this, pieceType);
        _moveTween = transform.DOMove(nextNode.transform.position, walkSpeed);
        RotateBody(direction);

        _currentNode = nextNode;
        _currentDirection = direction;

        _currentNode.EnterPiece(this, pieceType);    
    }

    protected void RotateBody(Direction direction)
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

    protected Node NextNodeDirection(Direction direction)
    {
        Node nextNode = null;

        foreach (var item in _currentNode.nodeDirections)
        {
            if (direction == item.direction)
            {
                nextNode = item.node;
            }
        }

        return nextNode;
    }
}
