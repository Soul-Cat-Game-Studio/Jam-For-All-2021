using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeDirection
{

    public Direction direction;

    [Range(0.0f, 360.0f)]
    public float rotationAngle;

    [SerializeField] private GameObject stick;

    public bool IsEnable { get => _isEnable; set => _isEnable = value; }
    [SerializeField] private bool _isEnable = true;

    public Node node;

    public void Verify()
    {
        if (IsEnable) stick.SetActive(true);
        else stick.SetActive(false);
    }

    public void ExitNode() => stick.SetActive(false);

}
