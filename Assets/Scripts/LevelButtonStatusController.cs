using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LevelButtonState
{
	Locked,
	Hidden,
	Unlocked
}

public class LevelButtonStatusController : MonoBehaviour
{
	[Serializable]
	public class StatesColors
	{
		public Color locked;

		public Color hidden;

		public Color unlocked;

		public Color GetColorForState(LevelButtonState state)
		{
			switch(state)
			{
				case LevelButtonState.Locked: return locked;
				case LevelButtonState.Hidden: return hidden;
				case LevelButtonState.Unlocked: return unlocked;
				default: throw new ArgumentOutOfRangeException("state");
			}
		}
	}

	public Image levelThumb;

	public Text lockIcon;

	public string defaultLockIconName = "LockIcon";

	public StatesColors levelThumbColors = new StatesColors
	{
		locked = new Color(0.0f, 0.0f, 0.0f, 0.3f),
		hidden = Color.black,
		unlocked = Color.white
	};

	public StatesColors lockIconColors = new StatesColors
	{
		locked = Color.white,
		hidden = new Color(0,0,0,0),
		unlocked = new Color(0,0,0,0)
	};

	// Use this for initialization
	void Start ()
	{
		if (levelThumb == null) levelThumb = gameObject.GetComponent<Image>();
		if (lockIcon == null) lockIcon = transform.FindChild(defaultLockIconName).GetComponent<Text>();	
	}

	public void SetButtonState(LevelButtonState state)
	{
		levelThumb.color = levelThumbColors.GetColorForState(state);
		lockIcon.color = lockIconColors.GetColorForState(state);
	}
}
