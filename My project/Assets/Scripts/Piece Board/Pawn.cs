using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    [SerializeField] private InputReader _input;
    [SerializeField] private bool _canMove = true;

    private void OnEnable()
    {
        _input.MoveEvent += HandlerMovement;
    }

    private void OnDisable()
    {
        _input.MoveEvent -= HandlerMovement;
    }

    public void HandlerMovement(Vector2 pos)
    {
        if (!_canMove)
        {
            _canMove = true;
            return;
        }

        _canMove = false;
        if (pos.x == 1) Move(Direction.Rigth);
        else if (pos.x == -1) Move(Direction.Left);
        else if (pos.y == 1) Move(Direction.Foward);
        else if (pos.y == -1) Move(Direction.Backwarrd);
    }
}
