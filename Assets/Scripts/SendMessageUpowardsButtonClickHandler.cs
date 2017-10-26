using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SendMessageUpowardsButtonClickHandler : MonoBehaviour {

	public Button button;

	public string methodName;

	public SendMessageOptions options;

	void Start ()
	{
		this.SetDefaultFromThis(ref button);
		button.onClick.AddListener((UnityAction)(() => this.SendMessageUpwards(methodName, options)));
	}
}
