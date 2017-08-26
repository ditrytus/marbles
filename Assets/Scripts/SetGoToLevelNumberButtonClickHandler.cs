using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SetGoToLevelNumberButtonClickHandler : MonoBehaviour {

	public LevelNumber levelNumber;

	public string levelNamePattern = "Level{0:D4}";

	public Button button;

	// Use this for initialization
	void Start ()
	{
		if (button == null) button = GetComponent<Button>();
		if (levelNumber == null) levelNumber = GetComponent<LevelNumber>();

		button.onClick.AddListener((UnityAction)(() => GameObject.FindObjectOfType<GoToSceneButtonHandler>().OnClick(string.Format(levelNamePattern, levelNumber.LevelNum))));
	}
}
