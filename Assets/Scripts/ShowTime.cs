using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour {

	public Text text;
	public PausableMainThreadScheduler scheduler;

	void Start()
	{
		scheduler = new PausableMainThreadScheduler();
		this.SetDefaultFromThis<Text>(ref text);
	}
	
	void Update ()
	{
		text.text = scheduler.Now.TimeOfDay.ToString();
		//text.text = PausableTime.Instance.Time.ToString("F2");
	}
}
