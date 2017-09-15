using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : PersistentToggle<Settings, SettingsFields>
{
    private const string FilePath = "settings.json";

    public SettingsToggle()
	: base(
		new Persistent<Settings>(
            FilePath,
			() => new Settings()
			{
				musicEnabled = true,
				soundEnabled = true
			}))
    { }
}
