using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_Squared : LineGenerator
{
    protected override float FunctionToCall(float x)
    {
        // Example function, replace with your desired function
        return x * x;
    }
}