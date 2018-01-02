using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions
{
	public static Color ChangeBrightness(this Color color, float brightness)
	{
		float h, s, v;
		Color.RGBToHSV(color, out h, out s, out v);
		return Color.HSVToRGB(h, s, brightness);
	}
}
