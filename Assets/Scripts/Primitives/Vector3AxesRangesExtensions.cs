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

    public static AxesFilter GetAxesOutOfRangeOrOnEdge(this Vector3 vector, AxesRanges range)
	{
		var filter = new AxesFilter();
		filter.x = !range.xRange.ContainsNotOnEdge(vector.x);        
		filter.y = !range.yRange.ContainsNotOnEdge(vector.y);
		filter.z = !range.zRange.ContainsNotOnEdge(vector.z);
		return filter;
	}
}