using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleColorController : MonoBehaviour {

	public MarbleColor color;

	public Material purpleMaterial;
	public Material yellowMaterial;
	public Material greenMaterial;
	public Material redMaterial;
	public Material blueMaterial;

	private Dictionary<MarbleColor, Material> colorMaterialMap;

	// Use this for initialization
	void Start ()
    {
        InitColorMaterialMap();
        SetMaterial();
    }

    private void SetMaterial()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = colorMaterialMap[color];
        }
    }

    private void InitColorMaterialMap()
    {
        colorMaterialMap = new Dictionary<MarbleColor, Material>()
        {
            {MarbleColor.Blue,   blueMaterial},
            {MarbleColor.Green,  greenMaterial},
            {MarbleColor.Purple, purpleMaterial},
            {MarbleColor.Red,    redMaterial},
            {MarbleColor.Yellow, yellowMaterial},
        };
    }

    public void SetColor(MarbleColor newColor)
	{
		this.color = newColor;
		SetMaterial();
	}
}
