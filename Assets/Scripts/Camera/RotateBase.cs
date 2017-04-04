using UnityEngine;

public abstract class RotateBase : MonoBehaviour
{
    public float rotateSpeed;

    public Transform rotationPoint;

    public GameObject rotatedObject;

    private bool isGliding = false;

    public float glide;

	private float glidedTime = 0;

    private float angularVelocity;

	public AxesFilter constraint = AxesFilter.All;

    public void Glide()
    {
        if (isGliding)
        {
            glidedTime += Time.deltaTime;

            RotateByAngle(Mathf.Lerp(angularVelocity, 0.0f, glidedTime / glide));

            if (glidedTime > glide)
            {
                isGliding = false;
            }
        }
    }

    public void StartGlide()
    {
        isGliding = true;
        glidedTime = 0;
    }

    public void Rotate(Vector2 delta)
    {
        angularVelocity = Vector2.Dot(delta, Vector2.right) * rotateSpeed;
        RotateByAngle(angularVelocity);
    }

    private void RotateByAngle(float angularVelocity)
    {
        rotatedObject.transform.RotateAround(
            rotationPoint.position,
            Vector2.up,
            angularVelocity);
    }

    public void EndGlide()
    {
        isGliding = false;
    }
}