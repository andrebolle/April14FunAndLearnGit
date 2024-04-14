using UnityEngine;

public class Perlin : SurfaceGenerator
{
    protected override float FunctionToCall(float x, float y)
    {
        // Scale the input values to a larger noise space (adjust as needed)
        float scaledX = x * .5f;
        float scaledY = y * .5f;

        // Sample Perlin noise at the scaled coordinates
        float noise = Mathf.PerlinNoise(scaledX, scaledY);

        // Scale the noise value to a desired height range (adjust as needed)
        return noise * 2f;
    }
}
