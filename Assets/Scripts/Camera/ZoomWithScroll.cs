using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ZoomWithScroll : ZoomBase
{
	void Update ()
	{
		var verticalDelta = Input.mouseScrollDelta.y;
		if (verticalDelta != 0)
        {
            var zoomCenter = Input.mousePosition;
            ZoomCameraInCenter(verticalDelta, zoomCenter);
        }
    }
}
