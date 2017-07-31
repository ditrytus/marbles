using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeTimeOnStart : MonoBehaviour
{
	void Start ()
	{
		PausableTime.Instance.Resume();
	}
}
