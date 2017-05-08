using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterController : MonoBehaviour {

	public ColorWheelController colorWheel;

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag(Tags.Marble))
		{
			var color = other.gameObject.GetComponent<MarbleColorController>();
			if (colorWheel.CurrentColor != MarbleColor.Joker)
			{
				color.SetColor(colorWheel.CurrentColor);
			}
		}
    }
}
