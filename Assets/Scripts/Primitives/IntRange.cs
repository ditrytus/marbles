using System;

[Serializable]
public class IntRange {
    public int min;
    public int max;

    public IntRange() : this(0, 0) { }

    public IntRange(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public bool Contains(int value)
    {
        return min <= value && value <= max;
    }

    public int Clamp(int value)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        return value;
    }
}