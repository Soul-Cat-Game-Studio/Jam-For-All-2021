using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    [Space(20)]
    [SerializeField] private InputReader _input;
    
    public override void OnEnable()
    {
        base.OnEnable();
        _input.MoveEvent += HandlerMovement;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        _input.MoveEvent -= HandlerMovement;
    }

    public override void StartPlayerTurn()
    {        
        _input.MoveEvent += HandlerMovement;
    }

    public void HandlerMovement(Vector2 pos)
    {
        if (pos.x == 1) Move(Direction.Rigth);
        else if (pos.x == -1) Move(Direction.Left);
        else if (pos.y == 1) Move(Direction.Foward);
        else if (pos.y == -1) Move(Direction.Backwarrd);
        else return;        

        _input.MoveEvent -= HandlerMovement;

        _turnManager.NextTurn();
    }
}
