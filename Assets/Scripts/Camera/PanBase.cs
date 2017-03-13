using UnityEngine;

public abstract class PanBase : MonoBehaviour
{
    public Camera cam;

    private bool isGliding = false;

    public float glide;

	private float glidedTime = 0;

    private Vector3 velocity;

	public AxesFilter constraint = AxesFilter.All;

    public AxesRanges boundary;

    public void Glide()
    {
        if (isGliding)
        {
            glidedTime += Time.deltaTime;

            if (!boundary.Contains(GlidedCamPos))
            {
                velocity = -velocity;
            }

            cam.transform.position = GlidedCamPos;


            if (glidedTime > glide)
            {
                isGliding = false;
            }
        }
    }

    private Vector3 GlidedCamPos
    {
        get
        {
            return cam.transform.position - Vector3.Lerp(velocity, Vector3.zero, glidedTime / glide);
        }
    }

    public void StartGlide()
    {
        isGliding = true;
        glidedTime = 0;
    }

    public void Pan(Vector2 delta)
    {
        var d = (Vector3)(delta) * cam.orthographicSize / cam.pixelHeight * 2f;

        var c = d / Mathf.Sin(0.5f * Mathf.PI - Mathf.Deg2Rad * Vector3.Angle(cam.transform.up, Vector3.up));

        velocity = c.Constrain(constraint);

        var movedPos = cam.transform.position - velocity;

        cam.transform.position = movedPos.Clamp(boundary);
    }

    public void EndGlide()
    {
        isGliding = false;
    }
}
