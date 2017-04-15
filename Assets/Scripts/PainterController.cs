using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterController : MonoBehaviour {

	public ColorWheelController colorWheel;

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Marble"))
		{
			var color = other.gameObject.GetComponent<MarbleColorController>();
			color.SetColor(colorWheel.CurrentColor);
		}
    }
}
