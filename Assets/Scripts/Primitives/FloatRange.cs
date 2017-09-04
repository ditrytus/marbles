using System;

[Serializable]
public class FloatRange {
    public float min;
    public float max;

    public bool Contains(float value)
    {
        return min <= value && value <= max;
    }

    public bool ContainsNotOnEdge(float value)
    {
        return min < value && value < max;        
    }

    public float Length
    {
        get
        {
            return max - min;
        }
    }

    public float Lerpify(float val)
    {
        return (val - min) / Length;
    }
}