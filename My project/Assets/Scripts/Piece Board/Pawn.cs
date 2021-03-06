using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    [Space(20)]
    [SerializeField] private InputReader _input;
    private bool _canMove;

    protected override void OnDisable()
    {
        base.OnDisable();
        _input.MoveEvent -= HandlerMovement;
    }

    protected override void Start()
    {
        base.Start();
        _turnManager.StartGame();
    }

    public override void StartPlayerTurn()
    {
        _input.MoveEvent += HandlerMovement;
        _canMove = true;
    }

    public override void Died()
    {
        base.Died();
        _input.MoveEvent -= HandlerMovement;
    }

    protected override bool Move(Direction direction)
    {
        if (!base.Move(direction)) return false;

        _canMove = false;

        _input.MoveEvent -= HandlerMovement;
        _turnManager.NextTurn();


        if (_currentNode.enemies.Count > 0)
        {
            foreach (var item in _currentNode.enemies)
            {
                item.Died();
            }

            _currentNode.enemies.Clear();
        }

        return true;
    }

    public void HandlerMovement(Vector2 pos)
    {
        if (!_canMove) return;

        if (pos.x == 1) Move(Direction.Rigth);
        else if (pos.x == -1) Move(Direction.Left);
        else if (pos.y == 1) Move(Direction.Foward);
        else if (pos.y == -1) Move(Direction.Backward);
    }
}
