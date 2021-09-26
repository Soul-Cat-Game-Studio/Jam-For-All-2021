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
                Verify();
                break;

            case PieceType.Enemy:
                enemies.Add(piece);
                break;
        }
    }

    private void Verify()
    {
        foreach (var item in nodeDirections)
        {
            item.Verify();
        }
    }

    private void ExitNode()
    {
        foreach (var item in nodeDirections)
        {
            item.ExitNode();
        }
    }

    public void EnableDiretion(int direction)
    {
        nodeDirections[direction].IsEnable = true;
    }

    public void DisableDiretion(int direction)
    {
        nodeDirections[direction].IsEnable = false;
    }

    public void ExitPiece(Piece piece, PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Player:
                player = null;
                ExitNode();
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
            if (item.node == null || !item.IsEnable) continue;
            Gizmos.DrawLine(transform.position, item.node.transform.position);
        }
    }
}
