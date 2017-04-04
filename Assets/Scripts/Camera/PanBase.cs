using UnityEngine;

public abstract class PanBase : MonoBehaviour
{
    public Camera cam;

    public GameObject pannedObject;

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

            var glidedCamPos = GetGlidedCamPos(velocity);

            if (!boundary.Contains(glidedCamPos))
            {
                var axesOutsideBoundary = glidedCamPos.GetAxesOutOfRangeOrOnEdge(boundary);
                if (axesOutsideBoundary.HasAll)
                {
                    velocity = -velocity;
                } 
                else
                {
                    velocity = velocity.Constrain(axesOutsideBoundary);
                }
                
                glidedCamPos = GetGlidedCamPos(velocity);
            }

            pannedObject.transform.position = glidedCamPos;

            if (glidedTime > glide)
            {
                isGliding = false;
            }
        }
    }

    private Vector3 GetGlidedCamPos(Vector3 velocity)
    {
        var glidedVelocity = Vector3.Lerp(velocity, Vector3.zero, glidedTime / glide);

        return GetPosMovedInLocalSpace(glidedVelocity);
    }

    private Vector3 GetPosMovedInLocalSpace(Vector3 velocity)
    {
        return pannedObject.transform.position - ProjectToVerticalPlane(Quaternion.Euler(0, pannedObject.transform.rotation.eulerAngles.y, 0) * velocity);
    }

    public void StartGlide()
    {
        isGliding = true;
        glidedTime = 0;
    }

    public void Pan(Vector2 delta)
    {
        var d = (Vector3)(delta) * cam.orthographicSize / cam.pixelHeight * 2f;

        Vector3 c = ProjectToVerticalPlane(d);

        velocity = c.Constrain(constraint);

        var newPosition = GetPosMovedInLocalSpace(velocity).Clamp(boundary);

        pannedObject.transform.position = newPosition;
    }

    private Vector3 ProjectToVerticalPlane(Vector3 d)
    {
        return d / Mathf.Sin(0.5f * Mathf.PI - Mathf.Deg2Rad * Vector3.Angle(cam.transform.up, Vector3.up));
    }

    public void EndGlide()
    {
        isGliding = false;
    }
}
