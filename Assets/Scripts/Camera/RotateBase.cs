using UnityEngine;

public abstract class RotateBase : MonoBehaviour
{
    public Camera cam;

    public float rotateSpeed;

    //public Vector3 rotationAxis;

    public Transform rotationPoint;

    private bool isGliding = false;

    public float glide;

	private float glidedTime = 0;

    private Vector3 velocity;

	//public AxesFilter constraint = AxesFilter.All;

    // public void Glide()
    // {
    //     if (isGliding)
    //     {
    //         glidedTime += Time.deltaTime;

    //         var glidedCamPos = GetGlidedCamPos(velocity);

    //         if (!boundary.Contains(glidedCamPos))
    //         {
    //             var axesOutsideBoundary = glidedCamPos.GetAxesOutOfRangeOrOnEdge(boundary);
    //             if (axesOutsideBoundary.HasAll)
    //             {
    //                 velocity = -velocity;
    //             } 
    //             else
    //             {
    //                 velocity = velocity.Constrain(axesOutsideBoundary);
    //             }
                
    //             glidedCamPos = GetGlidedCamPos(velocity);
    //         }

    //         cam.transform.position = glidedCamPos;


    //         if (glidedTime > glide)
    //         {
    //             isGliding = false;
    //         }
    //     }
    // }

    private Vector3 GetGlidedCamPos(Vector3 velocity)
    {
        return cam.transform.position - Vector3.Lerp(velocity, Vector3.zero, glidedTime / glide);
    }

    public void StartGlide()
    {
        //isGliding = true;
        glidedTime = 0;
    }

    public void Rotate(Vector2 delta)
    {
        cam.transform.RotateAround(
            rotationPoint.position,
            Vector2.up,
            Vector2.Dot(delta, Vector2.right) * rotateSpeed);
    }

    public void EndGlide()
    {
        isGliding = false;
    }
}