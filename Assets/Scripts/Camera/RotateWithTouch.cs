using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RotateWithTouch : RotateBase
{
	void Update()
    {
		if (Input.touchCount > 0)
        {
            EndGlide();
        }

        if (Input.touchCount == 2)
        {
            if (Input.touches.Any(t => t.phase == TouchPhase.Moved))
            {
				var touchA = Input.touches[0];
				var touchB = Input.touches[1];

				var newMiddle = Vector2.Lerp(touchA.position, touchB.position, 0.5f);
				var oldMiddle = Vector2.Lerp(touchA.position - touchA.deltaPosition, touchB.position - touchB.deltaPosition , 0.5f);
				
                var delta = newMiddle - oldMiddle;

                Rotate(delta);
            }
            else if (Input.touches.Any(t => t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled))
            {
                StartGlide();
            }
        }

        Glide();
    }
}
