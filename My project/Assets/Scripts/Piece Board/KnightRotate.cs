using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRotate : Knight
{
    private List<Direction> directions = new List<Direction>();
    private int directionPoint;

    protected override void Start()
    {
        base.Start();

        directions.Add(_currentDirection);
        foreach (var item in _currentNode.nodeDirections)
        {
            if (item.direction == _currentDirection) continue;

            directions.Add(item.direction);
        }
    }

    public override void StartEnemyTurn()
    {
        directionPoint = (directionPoint + 1) % directions.Count;

        RotateBody(directions[directionPoint]);

        base.StartEnemyTurn();


    }
}