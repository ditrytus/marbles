using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnify : MonoBehaviour
{
	public RectTransform rectTransform;

	public Camera viewportCamera;

	public Vector2 viewportMagnifyMaxPoint;

	public RectTransform panelTransform;

	public FloatRange magnifyRange;

	public float magnifyFactor = 0.5f;

	void Update ()
    {
        var distance = Vector2.Distance(GetMiddleWorldPoint(rectTransform), GetMiddleWorldPoint(panelTransform));
        var t = 1.0f - (distance / magnifyFactor);
        var scale = Mathf.Lerp(magnifyRange.min, magnifyRange.max, t);
        Debug.Log(string.Format("Distance: " + distance + " t: " + t + " scale: " + scale));
        rectTransform.localScale = new Vector3(scale, scale, scale);
    }

    private Vector3 GetMiddleWorldPoint(RectTransform transform)
    {
        Vector3[] corners = new Vector3[4];
        transform.GetWorldCorners(corners);
        Vector3 middle = Vector3.zero;
        for (int i = 0; i < corners.Length; i++)
        {
            middle += corners[0];
        }
        middle = middle / 4;
        return middle;
    }
}
