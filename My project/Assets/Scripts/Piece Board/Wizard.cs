using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Piece
{
    [Space(20)]
    public LineRenderer laser;
    public float range;

    [SerializeField] private Transform _targetTransform;

    public override void StartEnemyTurn()
    {
        UpdateLaser();
    }

    private void UpdateLaser()
    {

        laser.enabled = true;

        laser.SetPosition(0, _targetTransform.position);


        if (Physics.Raycast(_targetTransform.position, Vector3.forward,
         out var hit, range))
        {
            laser.SetPosition(1, _targetTransform.position + Vector3.forward * hit.distance);

            var piece = hit.collider.gameObject.GetComponent<Piece>();
            if (piece.pieceType == PieceType.Player) piece.Died();
        }
        else laser.SetPosition(1, _targetTransform.position + Vector3.forward * range);


    }
}

