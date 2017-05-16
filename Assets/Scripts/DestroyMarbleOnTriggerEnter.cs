using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMarbleOnTriggerEnter : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(Tags.Marble))
		{
			other.gameObject.SendMessage(MarbleMessages.ExplodeMarble);
		}
	}
}
