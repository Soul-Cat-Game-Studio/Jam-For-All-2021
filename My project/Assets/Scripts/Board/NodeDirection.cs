using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeDirection
{
    public enum Direction
    {
        Foward,
        Left,
        Rigth,
        Backwarrd
    }

    [SerializeField] private Direction _direction;

    public bool IsEnable { get => _isEnable; set => _isEnable = value; }
    [SerializeField] private bool _isEnable = true;

    public Node node;

}
