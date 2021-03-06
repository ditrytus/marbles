﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

public class FiloController : RxBehaviour
{
	public int maxCount = 5;

	public float upPositionAngle;

	public float downPositionAngle;

	public ContainerController container;

	public float switchTime = 1.0f;

	public float slowDownFactor = 0.1f;

	public  AudioSource audioSource;

	public float switchUpSoundDelay;

	public float switchDownSoundDelay;
	

	public AudioClip audioClip;

	private enum FiloState
	{
		Gathering,
		SettleBeforeSwitchingDown,
		SwitchingDown,
		Releasing,
		SwitchingUp
	}

	private FiloState state = FiloState.Gathering;

	private float startTime;



	private float TimeRatio
	{
		get
        {
            return CurrentTime / switchTime;
        }
    }

    private float CurrentTime
    {
		get
		{
			return PausableTime.Instance.Time - startTime;
		}
    }

	private Vector3 eulerAngles;

    void Start () {
		this.SetDefaultFromThis(ref audioSource);
		var sub1 = container.content.ObserveCountChanged(notifyCurrentCount:true)
			.Subscribe(count => {
				if (state == FiloState.Gathering && count >= maxCount)
				{
					state = FiloState.SettleBeforeSwitchingDown;
					Observable.Timer(TimeSpan.FromSeconds(switchDownSoundDelay))
						.Subscribe((l)=>{
							audioSource.PlayOneShot(audioClip);						
						});
				}
			});

		var sub2 = container.content.ObserveCountChanged(notifyCurrentCount:true)
			.Subscribe(count => {
				if (count == 0 && state == FiloState.Releasing)
				{
					state = FiloState.SwitchingUp;
					startTime = PausableTime.Instance.Time;
					Observable.Timer(TimeSpan.FromSeconds(switchUpSoundDelay))
						.Subscribe((l)=>{
							audioSource.PlayOneShot(audioClip);						
						});				
				}
			});

		AddSubscriptions(sub1, sub2);
	}

	void FixedUpdate()
	{
		if (PausableTime.Instance.IsPaused)
		{
			return;
		}

		if (state == FiloState.SettleBeforeSwitchingDown)
		{
			if (container.content.All(item => item.GetComponent<Rigidbody>().IsSleeping()))
			{
				state = FiloState.SwitchingDown;
				eulerAngles = transform.localEulerAngles;
				startTime = PausableTime.Instance.Time;
			}
		}
		if (state == FiloState.SwitchingDown)
		{
			SetRotation(Mathf.LerpAngle(upPositionAngle, downPositionAngle, Mathf.Pow(TimeRatio, 2)));
			if (CurrentTime >= switchTime)
			{
				SetRotation(downPositionAngle);
				state = FiloState.Releasing;
			}
		}
		if (state == FiloState.SwitchingUp)
		{
			SetRotation(Mathf.Lerp(downPositionAngle, upPositionAngle, Mathf.Pow(TimeRatio, 2)));
			if (CurrentTime >= switchTime)
			{
				SetRotation(upPositionAngle);
				state = FiloState.Gathering;
			}
		}
		if (state == FiloState.Releasing)
		{
			foreach (var item in container.content.Take(container.content.Count - 1))
			{
				var body = item.GetComponent<Rigidbody>();
				body.AddForce(-body.velocity * slowDownFactor, ForceMode.VelocityChange);
			}
		}
	}

	private void SetRotation(float newXAngle)
    {
        transform.localEulerAngles = new Vector3(
			newXAngle,
			eulerAngles.y,
			eulerAngles.z);
    }
}
