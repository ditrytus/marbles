using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
	private const string FilePath = "settings.json";

	[Serializable]
	public class SettingsState
	{
		public bool musicEnabled;

		public bool soundEnabled;
	}

    public Settings()
	{
		persistentState = new Persistent<SettingsState>(
			FilePath,
			() => new SettingsState()
			{
				musicEnabled = true,
				soundEnabled = true
			});
	}

	private Persistent<SettingsState> persistentState;

	public bool MusicEnabled
	{
		get
		{
			return persistentState.Subject.musicEnabled & SoundEnabled;
		}
		set
		{
			persistentState.Subject.musicEnabled = value;
			persistentState.Save();
		}
	}

	public bool SoundEnabled
	{
		get
		{
			return persistentState.Subject.soundEnabled;
		}
		set
		{
			persistentState.Subject.soundEnabled = value;
			persistentState.Save();
		}
	}
}

public enum SettingsFields
{
	musicEnabled,

	soundEnabled
}
