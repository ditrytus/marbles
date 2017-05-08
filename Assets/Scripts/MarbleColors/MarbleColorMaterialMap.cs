using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleColorMaterialMap : MonoBehaviour {

	public const string SetMarbleColorMaterialMessage = "SetMarbleColorMaterial";

	public Material purpleMaterial;
	public Material yellowMaterial;
	public Material greenMaterial;
	public Material redMaterial;
	public Material blueMaterial;
	public Material jokerMaterial;

	public Material GetMaterialForColor(MarbleColor color)
    {
        return new Dictionary<MarbleColor, Material>()
        {
            {MarbleColor.Blue,   blueMaterial},
            {MarbleColor.Green,  greenMaterial},
            {MarbleColor.Purple, purpleMaterial},
            {MarbleColor.Red,    redMaterial},
            {MarbleColor.Yellow, yellowMaterial},
			{MarbleColor.Joker, jokerMaterial}
        }
		[color];
    }
	
	public void SetMarbleColor(MarbleColor color)
	{
		BroadcastMessage(SetMarbleColorMaterialMessage, GetMaterialForColor(color));
	}
}
