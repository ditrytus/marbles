using System;

[Serializable]
public struct AxesFilter
{
    public AxesFilter(bool x, bool y, bool z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static AxesFilter All
    {
        get
        {
            return new AxesFilter()
            {
                x = true,
                y = true,
                z = true
            };
        }
    }

    public bool x;
    public bool y;
    public bool z;

    public bool HasAny
    {
        get
        {
            return x || y || z;
        }
    }

    public bool HasAll
    {
        get
        {
            return x && y && x;
        }
    }
}