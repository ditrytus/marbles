using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleColorColorMap : MonoBehaviour {

	public const string SetMarbleColorColor = "SetMarbleColorColor";

	public Color purpleMaterial;
	public Color yellowMaterial;
	public Color greenMaterial;
	public Color redMaterial;
	public Color blueMaterial;

	public Color GetColorForMarbleColor(MarbleColor color)
    {
        return new Dictionary<MarbleColor, Color>()
        {
            {MarbleColor.Blue,   blueMaterial},
            {MarbleColor.Green,  greenMaterial},
            {MarbleColor.Purple, purpleMaterial},
            {MarbleColor.Red,    redMaterial},
            {MarbleColor.Yellow, yellowMaterial},
        }
		[color];
    }
	
	public void SetMarbleColor(MarbleColor color)
	{
		BroadcastMessage(SetMarbleColorColor, GetColorForMarbleColor(color));
	}
}
