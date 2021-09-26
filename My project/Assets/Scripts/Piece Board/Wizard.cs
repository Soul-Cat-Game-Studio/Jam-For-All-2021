using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Piece
{
    [Space(20)]
    public LineRenderer laser;

    public float range;

    public override void StartEnemyTurn()
    {
        UpdateLaser();
    }

    private void UpdateLaser()
    {
        laser.enabled = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, range))
        {

            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, transform.TransformDirection(Vector3.forward) * hit.distance);
        }


    }


}

