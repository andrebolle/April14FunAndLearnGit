// 2024-04-04 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class RotatingSquare : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Start()
    {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices = {
            new Vector3(-0.5f, -0.5f, 0f),
            new Vector3(0.5f, -0.5f, 0f),
            new Vector3(-0.5f, 0.5f, 0f),
            new Vector3(0.5f, 0.5f, 0f)
        };

        int[] triangles = {
            0, 2, 1,
            2, 3, 1
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        filter.mesh = mesh;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Standard"));
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
