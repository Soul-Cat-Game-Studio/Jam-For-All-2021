using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeDirection
{

    public Direction direction;

    [Range(0.0f, 360.0f)]
    public float rotationAngle;

    public bool IsEnable { get => _isEnable; set => _isEnable = value; }
    [SerializeField] private bool _isEnable = true;

    public Node node;

}
