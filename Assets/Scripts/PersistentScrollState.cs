using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ScrollState
{
	public float horizontalNormalizedPosition;
}

public class PersistentScrollState : MonoBehaviour
{
	private const string ScrollStateFilePath = "menu_scroll.json";

    private Persistent<ScrollState> scrollState;

	public ScrollRect scrollRect;

    void Start()
    {
		this.SetDefaultFromThis(ref scrollRect);
        scrollState = new Persistent<ScrollState>(ScrollStateFilePath, () => new ScrollState() { horizontalNormalizedPosition = scrollRect.horizontalNormalizedPosition });
		Debug.Log("LOAD HNP: " + scrollState.Subject.horizontalNormalizedPosition);
		scrollRect.horizontalNormalizedPosition = scrollState.Subject.horizontalNormalizedPosition;
    }

	public void LevelSelected()
	{
		scrollState.Subject.horizontalNormalizedPosition = scrollRect.horizontalNormalizedPosition;
		Debug.Log("SAVE HNP: " + scrollState.Subject.horizontalNormalizedPosition);
		scrollState.Save();		
	}
}
