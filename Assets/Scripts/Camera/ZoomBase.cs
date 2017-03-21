using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ZoomBase : MonoBehaviour {

	public List<Camera> zoomCameras = new List<Camera>();

	public float zoomSpeed = 0.1f;

    public FloatRange sizeRange;

	private PanBase pan;

	void Start()
	{
		pan = GetComponent<PanBase>();
	}

    protected void ZoomCameraInCenter(float zoomDelta, Vector3 zoomCenter)
    {
        zoomCameras.ForEach(cam =>
        {
            var oldWorldPos = cam.ScreenToWorldPoint(zoomCenter);
            var newSize = cam.orthographicSize + zoomDelta * zoomSpeed;
            
            if (sizeRange.Contains(newSize))
            {
                cam.orthographicSize = newSize;
                var newWorldPos = cam.WorldToScreenPoint(oldWorldPos);
                pan.Pan(zoomCenter - newWorldPos);
            }
        });
    }
}
