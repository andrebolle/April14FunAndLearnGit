using UnityEngine;
using UnityEngine.UIElements;

public class RandomLineRenderer : MonoBehaviour
{
    public int numPoints = 1000;
    public float lengthOfDrawVolumeSide = 500f;
    private LineRenderer lineRenderer;
    public float rotationSpeed = 20f;
    private Vector3[] points;
    public float lineWidth = 2f;

    void Start()
    {
        points = new Vector3[numPoints];
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // Generate random positions within a range (modify as needed)
        for (int i = 0; i < numPoints; i++)
        {
            float randomX = Random.Range(-lengthOfDrawVolumeSide, lengthOfDrawVolumeSide); // adjust Y range for vertical movement
            float randomY = Random.Range(-lengthOfDrawVolumeSide, lengthOfDrawVolumeSide); // adjust Y range for vertical movement
            float randomZ = Random.Range(-lengthOfDrawVolumeSide, lengthOfDrawVolumeSide); // adjust Y range for vertical movement

            points[i] = new Vector3(randomX, randomY, randomZ);
        }

        // Set the positions of the LineRenderer
        lineRenderer.positionCount = numPoints;
        lineRenderer.SetPositions(points);
    }

    private void Update()
    {
        lineRenderer.positionCount = (int)(Time.time * 10) % numPoints;
        lineRenderer.SetPositions(points);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
