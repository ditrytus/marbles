using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class SetPositionBetween : MonoBehaviour {

	public bool setOnStart = true;

	public bool setOnUpdate = true;

	public Transform[] objects;

	public Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		if (setOnStart)
        {
            SetPosition();
        }
    }

    private void SetPosition()
    {
		if (objects.Any())
		{
			transform.position =
				offset +
				(
					objects.LongLength == 1
						? objects[0].position
						: objects
							.Select(o => o.position)
							.Aggregate((p1, p2) => Vector3.Lerp(p1, p2, 0.5f))
				);
		}
    }

    // Update is called once per frame
    void Update ()
	{
		if (setOnUpdate)
		{
            SetPosition();
			
		}	
	}
}
