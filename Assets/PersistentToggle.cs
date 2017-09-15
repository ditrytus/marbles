using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public abstract class PersistentToggle<TSettings, TFields> : MonoBehaviour
{
	public Toggle toggle;

	private Persistent<TSettings> settings;

	public TFields field;

	protected PersistentToggle(Persistent<TSettings> settings)
	{
		this.settings = settings;
	}

	void Start ()
	{
		this.SetDefaultFromThis(ref toggle);
		toggle.onValueChanged.AddListener(OnValueChanged);
        toggle.isOn = (bool)GetField().GetValue(settings.Subject);
	}
	
	public void OnValueChanged(bool value)
    {
        GetField().SetValue(settings.Subject, value);
        settings.Save();
    }

    private FieldInfo GetField()
    {
        return typeof(TSettings).GetField(field.ToString());
    }
}
