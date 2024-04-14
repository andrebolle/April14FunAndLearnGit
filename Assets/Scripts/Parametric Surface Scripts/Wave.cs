using UnityEngine;

public class Wave : SurfaceGenerator
{
    protected override float FunctionToCall(float x, float y)
    {
        // Example function, replace with your desired function
        return Mathf.Sin(x) + Mathf.Cos(y);
    }
}
