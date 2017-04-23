using System;
using UnityEngine;

public static class Vector3AxesFilterExtensions
{
    public static Vector3 Constrain(this Vector3 vector, AxesFilter constraint)
    {
        return FilterCombine(Vector3.zero, vector, constraint);
        // return new Vector3(
        //     constraint.x ? 0.0f : vector.x,
        //     constraint.y ? 0.0f : vector.y,
        //     constraint.z ? 0.0f : vector.z);
    }

    public static Vector3 Filter(this Vector3 vector, AxesFilter filter)
    {
        return FilterCombine(vector, Vector3.zero, filter);
    }

    public static Vector3 FilterCombine(this Vector3 vector, Vector3 other, AxesFilter filter)
    {
        return new Vector3(
            filter.x ? vector.x : other.x,
            filter.y ? vector.y : other.y,
            filter.z ? vector.z : other.z);
    }

    public static Vector3 ToDirection(this AxesFilter filter)
    {
        return Filter(new Vector3(1.0f, 1.0f, 1.0f), filter);
    }
}