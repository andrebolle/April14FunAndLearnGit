using UnityEngine;



public abstract class LineGenerator : MonoBehaviour
{
    public int numberOfPoints = 100;
    public float curveWidth = 0.1f;
    public Color curveColor = Color.red;
    public float minX = -5f;
    public float maxX = 5f;
    public float rotationSpeed = 100f;

    void Start()
    {
        DrawCurve();
    }

    protected abstract float FunctionToCall(float x);

    void DrawCurve()
    {

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
        lineRenderer.startWidth = curveWidth;
        lineRenderer.endWidth = curveWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = curveColor;
        lineRenderer.endColor = curveColor;

        float step = (maxX - minX) / (numberOfPoints - 1);

        for (int i = 0; i < numberOfPoints; i++)
        {
            float x = minX + i * step;
            float y = FunctionToCall(x);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}


