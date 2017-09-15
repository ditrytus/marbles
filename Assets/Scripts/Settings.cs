using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Settings
{
	public bool musicEnabled;

	public bool soundEnabled;
}

public enum SettingsFields
{
	musicEnabled,

	soundEnabled
}
