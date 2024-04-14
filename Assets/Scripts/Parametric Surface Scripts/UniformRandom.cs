using UnityEngine;

public class UniformRandom : SurfaceGenerator
{
    protected override float FunctionToCall(float x, float y)
    {
        return Random.Range(0f, 1f)*2.0f;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, 20f * Time.deltaTime);
    }
}
