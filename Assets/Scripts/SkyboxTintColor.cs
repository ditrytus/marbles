using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTintColor : MonoBehaviour {
	
	public Skybox skybox;

	public Color tintColor;

	private Color previousColor;
	
	void Update () {
		if (previousColor != tintColor)
		{
			skybox.material.SetColor("_SkyTint", tintColor);
			previousColor = tintColor;
		}
	}
}
