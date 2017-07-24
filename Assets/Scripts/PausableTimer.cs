using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausableTimer : MonoBehaviour
{
	public Text text;
	
	void Update ()
	{
		text.text = PausableTime.Instance.Time.ToString("F1") + " " +
					PausableTime.Instance.gapTime.ToString("F1") + " " +
					PausableTime.Instance.UtcNow.TimeOfDay.ToString() +
					"\n\n" +
					PausableTime.Instance.UnscaledTime.ToString("F1") + " " +
					PausableTime.Instance.unscaledGapTime.ToString("F1") + " " +
					PausableTime.Instance.UnscaledUtcNow.TimeOfDay.ToString();
	}
}
