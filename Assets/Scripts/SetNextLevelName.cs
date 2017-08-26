using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class SetNextLevelName : MonoBehaviour
{
	public Button button;

	public GoToSceneButtonHandler handler;

	void Start ()
    {
        button.onClick.AddListener((UnityAction)(() => handler.OnClick(LevelNameHelper.GetNextLevelName())));
    }
}
