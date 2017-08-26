using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelNumberText : MonoBehaviour {

	public LevelNumber levelNumber;

	public Text levelNumberText;

	public string defaultLevelNumberObjectName = "LevelNumber";

	void Start ()
	{
		if (levelNumber == null) levelNumber = GetComponent<LevelNumber>();
		if (levelNumberText == null) levelNumberText = transform.FindChild(defaultLevelNumberObjectName).GetComponent<Text>();

		levelNumberText.text = levelNumber.LevelNum.ToString();
	}
}
