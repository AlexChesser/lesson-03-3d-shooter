using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct RangedFloat
{
    public float minValue;
    public float maxValue;

    public RangedFloat(float min, float max) {
        minValue = min;
        maxValue = max;
    }
}
