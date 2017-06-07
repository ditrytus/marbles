using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnEnter : ShakeBase
{
    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag(Tags.Marble))
        {
            StartShaking();
        }
    }
}
