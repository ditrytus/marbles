using UnityEngine;

public static class Vector3AxesRangesExtensions
{
    public static Vector3 Clamp(this Vector3 vector, AxesRanges range)
    {
        return new Vector3(
            Mathf.Clamp(vector.x, range.xRange.min, range.xRange.max),
            Mathf.Clamp(vector.y, range.yRange.min, range.yRange.max),
            Mathf.Clamp(vector.z, range.zRange.min, range.zRange.max)
        );
    }    
}