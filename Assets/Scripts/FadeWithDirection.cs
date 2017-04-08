using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWithDirection : MonoBehaviour {

	public Vector3 direction;
	
	public Transform relativeObject;

	public string defaultRelativeObjectTag = "MainCamera";

	public float opaqueAngle;

	public float transparentAngle;

	private float previousAngle = 0.0f;

	void Start()
	{
		if (relativeObject == null)
		{
			relativeObject = GameObject.FindGameObjectWithTag(defaultRelativeObjectTag).transform;
		}
	}
	
	void Update () {
		var angle = Vector3.Angle(transform.TransformDirection(direction), relativeObject.TransformDirection(Vector3.forward));

		if (angle == previousAngle)
		{
			return;
		}

		previousAngle = angle;

		float firstAngleThreshold = Mathf.Min(opaqueAngle, transparentAngle);
		float secondAngleThreshold = Mathf.Max(opaqueAngle, transparentAngle);
		
		bool smallerOpaque = opaqueAngle < transparentAngle;
		var firstAngleAlpha = smallerOpaque ? 1.0f : 0.0f;
		var secondAngleAlpha = smallerOpaque ? 0.0f : 1.0f;

		var alpha = 0.0f;

		if (angle <= firstAngleThreshold)
		{
			 alpha = firstAngleAlpha;
		}
		else if (angle > firstAngleThreshold && angle <=secondAngleThreshold)
		{
			var t = (angle - firstAngleThreshold)/(secondAngleThreshold - firstAngleThreshold);
			alpha = Mathf.Lerp(firstAngleAlpha, secondAngleAlpha, t);
		}
		else
		{
			alpha = secondAngleAlpha;
		}

		var material = gameObject.GetComponent<Renderer>().material;
		material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
	}
}
