using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomEmission : MonoBehaviour
{
	public Color[] colorPool;

	public float brightness;

	private static List<int> usedColors;

	void Start ()
	{
		if (usedColors == null)
		{
			usedColors = Enumerable.Range(0, colorPool.Length).ToList();
		}

		var renderer = GetComponent<Renderer>();

		var randomIndex = Random.Range(0, usedColors.Count);

		var randomColor = colorPool[usedColors[randomIndex]];

		renderer.material.SetColor("_EmissionColor", randomColor.ChangeBrightness(brightness));

		usedColors.RemoveAt(randomIndex);
	}
}
