using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeDirection
{

    public Direction direction;

    public bool IsEnable { get => _isEnable; set => _isEnable = value; }
    [SerializeField] private bool _isEnable = true;

    public Node node;

}
