using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System;

public class SetNextLevelName : MonoBehaviour
{
	public Button button;

	public GoToSceneButtonHandler handler;

	void Start ()
	{
        button.onClick.AddListener((UnityAction)(() => handler.OnClick("Level" + (int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"(\d+)$").Groups[1].Value) + 1).ToString("D4"))));
	}
}
