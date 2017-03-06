using System;

[Serializable]
public struct AxesFilter
{
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
}