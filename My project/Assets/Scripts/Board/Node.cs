using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<NodeDirection> nodeDirections;

    public List<Piece> enemies;
    public Piece player;

    public void EnterPiece(Piece piece, PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Player:
                player = piece;
                break;

            case PieceType.Enemy:
                enemies.Add(piece);
                break;
        }
    }

    public void ExitPiece(Piece piece, PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Player:
                player = null;
                break;

            case PieceType.Enemy:
                enemies.Remove(piece);
                break;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (var item in nodeDirections)
        {
            if (item.node == null) continue;
            Gizmos.DrawLine(transform.position, item.node.transform.position);
        }
    }
}
