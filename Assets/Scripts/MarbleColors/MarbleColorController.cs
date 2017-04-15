using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleColorController : MonoBehaviour {

    public const string SetMarbleColorMessage = "SetMarbleColor";

	public MarbleColor color;

	void Start ()
    {
        SetColor(color);
    }

    public void SetColor(MarbleColor newColor)
	{
		this.color = newColor;
        BroadcastMessage(SetMarbleColorMessage, newColor);
	}
}
