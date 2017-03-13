using UnityEngine;
using System;
using System.Linq;

public class PanOnTouch : PanBase
{
	void Update()
    {
		if (Input.touchCount > 0)
        {
            EndGlide();
        }

        if (Input.touchCount == 1)
        {
            var touch = Input.touches.First();
            if (touch.phase == TouchPhase.Moved)
            {
                var delta = touch.deltaPosition;
                Pan(delta);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                StartGlide();
            }
        }

        Glide();
    }
}
