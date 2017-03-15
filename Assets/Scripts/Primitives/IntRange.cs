using System;

[Serializable]
public class IntRange {
    public int min;
    public int max;

    public bool Contains(int value)
    {
        return min <= value && value <= max;
    }
}