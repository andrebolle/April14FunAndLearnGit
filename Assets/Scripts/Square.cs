using UnityEngine;

public class Square : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private LineRenderer lineRenderer;
    private Vector3[] positions = new Vector3[5];

    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 5;

        positions[0] = new Vector3(-0.5f, -0.5f, 0f);
        positions[1] = new Vector3(0.5f, -0.5f, 0f);
        positions[2] = new Vector3(0.5f, 0.5f, 0f);
        positions[3] = new Vector3(-0.5f, 0.5f, 0f);
        positions[4] = positions[0]; // Close the square

        lineRenderer.SetPositions(positions);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}