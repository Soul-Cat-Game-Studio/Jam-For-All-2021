using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Piece
{
    [SerializeField] private List<Direction> directions;

    private int nextPoint;


    public override void StartPlayerTurn()
    {


        Move(directions[nextPoint]);
        nextPoint++;

        if (nextPoint >= directions.Count)
        {
            directions = ChangeDirection(directions);
            nextPoint = 0;
        }


        if (_currentNode.player) _currentNode.player.Died();
    }

    private List<Direction> ChangeDirection(List<Direction> directions)
    {
        List<Direction> newDirections = new List<Direction>();

        newDirections = directions;
        newDirections.Reverse();

        for (int i = 0; i < newDirections.Count; i++)
        {
            var dir = newDirections[i];
            switch (dir)
            {
                case Direction.Foward:
                    dir = Direction.Backward;
                    break;

                case Direction.Backward:
                    dir = Direction.Foward;
                    break;
                case Direction.Left:
                    dir = Direction.Rigth;
                    break;
                case Direction.Rigth:
                    dir = Direction.Left;
                    break;
            }

            newDirections[i] = dir;
        }

        return newDirections;
    }


}
