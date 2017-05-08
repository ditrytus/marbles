﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchController : MonoBehaviour {

	public MarbleColorController leftColor;

	public Collider leftRail;

	public MarbleColorController rightColor;

	public Collider rightRail;

	private Dictionary<Collider,Collider> ignoredPairs = new Dictionary<Collider,Collider> ();

	void OnTriggerEnter(Collider other)
	{
		var marble = other.gameObject;
		if (marble.CompareTag(Tags.Marble))
		{
			var marbleColorController = marble.GetComponent<MarbleColorController>();
			if (marbleColorController == null)
			{
				return;
			}
			if (marbleColorController.color.ColorEquals(leftColor.color))
			{
				Physics.IgnoreCollision(other, rightRail, true);
				ignoredPairs.Add(other, rightRail);
			}
			else if (marbleColorController.color.ColorEquals(rightColor.color))
			{
				Physics.IgnoreCollision(other, leftRail, true);
				ignoredPairs.Add(other, leftRail);
			}
			else
			{
				var destroyOnWrongColor = marble.GetComponent<DestroyOnWrongColor>();
				destroyOnWrongColor.delay = 0.125f;
				destroyOnWrongColor.MarbleColorIsWrong();
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (ignoredPairs.ContainsKey(other))
		{
			Physics.IgnoreCollision(other, ignoredPairs[other]);
			ignoredPairs.Remove(other);
		}
	}
}
