using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AlphaController : MonoBehaviour
{
	public float alpha = 1.0f;

	private SpriteRenderer[] spriteRenderers;

	private TextMesh[] textMeshes;

	void Awake()
	{
		spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
		textMeshes = gameObject.GetComponentsInChildren<TextMesh>();
	}
	
	void Update ()
	{
		foreach(var spriteRenderer in spriteRenderers)
		{
			var newColor = spriteRenderer.color;
			newColor.a = alpha;
			spriteRenderer.color = newColor;
		}
		foreach(var textMesh in textMeshes)
		{
			var newColor = textMesh.color;
			newColor.a = alpha;
			textMesh.color = newColor;
		}
	}
}
