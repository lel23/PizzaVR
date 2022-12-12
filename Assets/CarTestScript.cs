using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarTestScript : MonoBehaviour
{
    public List<Vector3> points;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (var point in points)
        {
            Gizmos.DrawWireCube(point, Vector3.one);
        }
    }
}
