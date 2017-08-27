using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCurrentLevelNumberText : MonoBehaviour
{
	public Text text;

	public string textFormat = "level {0}";

	void Start ()
	{
		if (text == null) text = GetComponent<Text>();
		text.text = string.Format(textFormat, LevelNameHelper.GetCurrentLevelNumber());
	}
}
