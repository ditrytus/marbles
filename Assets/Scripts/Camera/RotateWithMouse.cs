using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : RotateBase {

	public int mouseRotateButton = 1;

	private Vector3? previousMousePosition = new Vector3();

	void Update()
    {
        if (Input.GetMouseButton(mouseRotateButton))
        {
            if (Input.GetMouseButtonDown(mouseRotateButton))
            {
                EndGlide();
            }

			if (previousMousePosition.HasValue)
			{
            	Rotate(Input.mousePosition - previousMousePosition.Value);
			}

            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(mouseRotateButton))
        {
            StartGlide();
        }

		if (!Input.GetMouseButton(mouseRotateButton))
		{
			previousMousePosition = null;
		}

        Glide();
    }
}
