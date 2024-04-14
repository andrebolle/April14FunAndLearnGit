using UnityEngine;

public class Helix : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public float radius = 1f;
    public float height = 2f;
    public int segments = 500;
    public float lineWidth = 0.1f; // New variable for line width
    public float rotationSpeed = 100f; // New variable for rotation speed
    private float xRotation;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupLineRenderer();
        DrawHelix();
    }

    void SetupLineRenderer()
    {
        lineRenderer.positionCount = segments + 1; // Add 1 for a closed loop
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    void DrawHelix()
    {
        Vector3[] positions = new Vector3[segments + 1];

        for (int i = 0; i <= segments; i++)
        {
            float t = Mathf.PI * 2f * 10f * (float)i / segments;
            float x = radius * Mathf.Cos(t);
            float y = radius * Mathf.Sin(t);
            float z = t * height / (Mathf.PI * 2f);
            positions[i] = new Vector3(x, y, z);
        }

        lineRenderer.SetPositions(positions);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
