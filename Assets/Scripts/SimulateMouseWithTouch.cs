using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateMouseWithTouch : MonoBehaviour {

	public bool value;
	
	void Start () {
		Input.simulateMouseWithTouches = value;
	}
}
