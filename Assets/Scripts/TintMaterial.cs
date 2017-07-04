using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class TintMaterial : MonoBehaviour
{
	public Color color;

	public Renderer[] renderers;

	private MaterialPropertyBlock[] propBlocks;

	public Color initialColor;

	void Start ()
	{
		propBlocks = new MaterialPropertyBlock[renderers.Length];
		for (int i=0; i<renderers.Length; i++)
		{
			propBlocks[i] = new MaterialPropertyBlock();
			renderers[i].GetPropertyBlock(propBlocks[i]);
		}
	}
	
	void Update ()
    {
        SetTintColor(color);
    }

    private void SetTintColor(Color newColor)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetPropertyBlock(propBlocks[i]);

            propBlocks[i].SetColor("_Color", newColor);

            renderers[i].SetPropertyBlock(propBlocks[i]);
        }
    }

    void OnDisable()
	{
		SetTintColor(initialColor);
	}
}
