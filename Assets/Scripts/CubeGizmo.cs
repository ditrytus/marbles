using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGizmo : MonoBehaviour
{
	public Color color = Color.yellow;

	void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
	}
}
