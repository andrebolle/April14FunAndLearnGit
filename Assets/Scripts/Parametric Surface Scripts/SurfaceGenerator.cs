using UnityEngine;

public abstract class SurfaceGenerator : MonoBehaviour
{
    // The number of points along the x and z axes of the mesh
    public int resolutionX = 50;
    public int resolutionZ = 50;

    // The width and height of the surface in world units
    public float width = 10f;
    public float height = 10f;

    // The color of the surface
    public Color surfaceColor = Color.white;

    void Start()
    {
        // Draw the parametric surface mesh
        DrawSurface();
    }

    protected abstract float FunctionToCall(float x, float y);

    protected void DrawSurface()
    {
        // Add a MeshFilter and MeshRenderer component to the GameObject
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create a new mesh
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        // Create arrays to store the vertices (positions) and UV coordinates
        Vector3[] vertices = new Vector3[(resolutionX + 1) * (resolutionZ + 1)];
        Vector2[] uv = new Vector2[vertices.Length];

        // Loop through each vertex in the mesh
        for (int z = 0, index = 0; z <= resolutionZ; z++)
        {
            for (int x = 0; x <= resolutionX; x++, index++)
            {
                // Calculate the normalized position of the vertex on the x and z axes
                float xPercent = (float)x / resolutionX;
                float zPercent = (float)z / resolutionZ;

                // Calculate the actual x, y, and z positions of the vertex
                float xPos = Mathf.Lerp(-width / 2f, width / 2f, xPercent);
                float zPos = Mathf.Lerp(-height / 2f, height / 2f, zPercent);
                float yPos = FunctionToCall(xPos, zPos);

                // Set the vertex position and UV coordinates
                vertices[index] = new Vector3(xPos, yPos, zPos);
                uv[index] = new Vector2(xPercent, zPercent);
            }
        }

        // Assign the vertex and UV data to the mesh
        mesh.vertices = vertices;
        mesh.uv = uv;

        // Create an array to store the triangle indices
        int[] triangles = new int[6 * resolutionX * resolutionZ];

        // Loop through each quad in the mesh and create triangles
        for (int ti = 0, vi = 0, y = 0; y < resolutionZ; y++, vi++)
        {
            for (int x = 0; x < resolutionX; x++, ti += 6, vi++)
            {
                // Define the indices of the four vertices of the quad
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + resolutionX + 1;
                triangles[ti + 5] = vi + resolutionX + 2;

                // These indices define two triangles that make up the quad
            }
        }

        // Assign the triangle data to the mesh
        mesh.triangles = triangles;

        // Recalculate normals for proper lighting
        mesh.RecalculateNormals();

        // Create a new material and set its color
        Material material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        material.color = surfaceColor;

        // Assign the material to the mesh renderer
        meshRenderer.material = material;
    }
}
