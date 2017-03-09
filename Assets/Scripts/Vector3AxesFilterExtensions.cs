using System;
using UnityEngine;

public static class Vector3AxesFilterExtensions
{
    public static Vector3 Constrain(this Vector3 vector, AxesFilter constraint)
    {
        return new Vector3(
            constraint.x ? 0.0f : vector.x,
            constraint.y ? 0.0f : vector.y,
            constraint.z ? 0.0f : vector.z);
    }

    public static Vector3 Filter(this Vector3 vector, AxesFilter filter)
    {
        return FilterCombine(vector, Vector3.zero, filter);

        // return new Vector3(
        //     filter.x ? vector.x : 0.0f,
        //     filter.y ? vector.y : 0.0f,
        //     filter.z ? vector.z : 0.0f);
    }

    public static Vector3 FilterCombine(this Vector3 vector, Vector3 other, AxesFilter filter)
    {
        return new Vector3(
            filter.x ? vector.x : other.x,
            filter.y ? vector.y : other.y,
            filter.z ? vector.z : other.z);
    }
}