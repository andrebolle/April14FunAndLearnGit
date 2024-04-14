using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//public class CreateAxisCylinders : MonoBehaviour
//{
//    public float axisLength = 5f;
//    public float axisThickness = 0.05f;
//    public Color xAxisColor = Color.red;
//    public Color yAxisColor = Color.green;
//    public Color zAxisColor = Color.blue;

//    void Start()
//    {
//        DrawAxis(Vector3.right, xAxisColor); // X-Axis
//        DrawAxis(Vector3.up, yAxisColor); // Y-Axis
//        DrawAxis(Vector3.forward, zAxisColor); // Z-Axis
//    }

//    void DrawAxis(Vector3 direction, Color color)
//    {
//        GameObject axis = new GameObject("Axis");
//        axis.transform.parent = transform;

//        LineRenderer lineRenderer = axis.AddComponent<LineRenderer>();
//        lineRenderer.positionCount = 2;
//        lineRenderer.useWorldSpace = false;
//        lineRenderer.startWidth = axisThickness;
//        lineRenderer.endWidth = axisThickness;
//        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
//        lineRenderer.startColor = color;
//        lineRenderer.endColor = color;

//        Vector3 startPos = Vector3.zero;
//        Vector3 endPos = direction * axisLength;

//        lineRenderer.SetPosition(0, startPos);
//        lineRenderer.SetPosition(1, endPos);
//    }
//}



public class CreateAxisCylinders : MonoBehaviour
{
    public float axisLength = 5f;
    public float axisThickness = 0.05f;
    public Color xAxisColor = Color.red;
    public Color yAxisColor = Color.green;
    public Color zAxisColor = Color.blue;

    void Start()
    {
        DrawAxis(Vector3.right, xAxisColor, "RedAxis"); // X-Axis
        DrawAxis(Vector3.up, yAxisColor, "GreenAxis"); // Y-Axis
        DrawAxis(Vector3.forward, zAxisColor, "BlueAxis"); // Z-Axis
    }

    void DrawAxis(Vector3 direction, Color color, string axisName)
    {
        GameObject axis = new GameObject(axisName);
        axis.transform.parent = transform;

        LineRenderer lineRenderer = axis.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = axisThickness;
        lineRenderer.endWidth = axisThickness;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        Vector3 startPos = -direction * axisLength / 2f;
        Vector3 endPos = direction * axisLength / 2f;

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}

