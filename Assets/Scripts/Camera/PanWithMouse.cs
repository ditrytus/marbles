using UnityEngine;
using System;
using System.Linq;

public class PanWithMouse : PanBase {

	public int mousePanButton = 0;

	private Vector3? previousMousePosition = new Vector3();

	void Update()
    {
        if (Input.GetMouseButton(mousePanButton))
        {
            if (Input.GetMouseButtonDown(mousePanButton))
            {
                EndGlide();
            }

			if (previousMousePosition.HasValue)
			{
            	Pan(Input.mousePosition - previousMousePosition.Value);
			}

            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(mousePanButton))
        {
            StartGlide();
        }

		if (!Input.GetMouseButton(mousePanButton))
		{
			previousMousePosition = null;
		}

        Glide();
    }
}
