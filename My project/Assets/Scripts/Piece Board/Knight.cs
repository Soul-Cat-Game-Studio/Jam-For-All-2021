using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override void StartEnemyTurn()
    {
        var nextNode = NextNodeDirection(_currentDirection);

        if (nextNode != null && nextNode.player != null)
        {
            nextNode.player.Died();
            Move(_currentDirection);
        }
    }
}

