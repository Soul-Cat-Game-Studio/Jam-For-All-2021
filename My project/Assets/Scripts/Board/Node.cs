using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<NodeDirection> nodeDirections;


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
