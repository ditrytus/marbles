using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Curve : MonoBehaviour {

	public Transform[] points;

	public LineRenderer lineRenderer;

	private Vector3[] oldPoints;

    public Vector3[] positions;

    public float length;

	public float smoothness = 3.0f;

	// Use this for initialization
	void Start ()
    {
        var points = GetPoints();

        SetPoints(points);
    }

    private void SetPoints(Vector3[] points)
    {
        oldPoints = points;
        positions = MakeSmoothCurve(points, smoothness);
        SetLendth();
        RenderCurve(positions);
    }

    private void SetLendth()
    {
        length = 0;
        for (int i = 0; i < positions.Length - 1; i++)
        {
            length += Vector3.Distance(positions[i], positions[i + 1]);
        }
    }

    private Vector3[] GetPoints()
    {
        return points.Select(p => p.position).ToArray();
    }

    private void RenderCurve(Vector3[] positions)
    {
        lineRenderer.numPositions = positions.Length;
        for (int i = 0; i < positions.Length; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }
    }

    // Update is called once per frame
    void Update ()
	{
		var points = GetPoints();
		bool changed = true;
		if (points.Length == oldPoints.Length)
		{
			changed = false;
			for(int i=0; i<points.Length; i++)
			{
				if (points[i] != oldPoints[i])
				{
					changed = true;
				}
			}
		}
		if (changed)
		{
			SetPoints(points);
		}
	}

	public Vector3[] MakeSmoothCurve(Vector3[] arrayToCurve,float smoothness)
	{
         List<Vector3> points;
         List<Vector3> curvedPoints;
         int pointsLength = 0;
         int curvedLength = 0;
         
         if(smoothness < 1.0f) smoothness = 1.0f;
         
         pointsLength = arrayToCurve.Length;
         
         curvedLength = (pointsLength * Mathf.RoundToInt(smoothness))-1;
         curvedPoints = new List<Vector3>(curvedLength);
         
         float t = 0.0f;
         for(int pointInTimeOnCurve = 0;pointInTimeOnCurve < curvedLength+1;pointInTimeOnCurve++){
             t = Mathf.InverseLerp(0,curvedLength,pointInTimeOnCurve);
             
             points = new List<Vector3>(arrayToCurve);
             
             for(int j = pointsLength-1; j > 0; j--){
                 for (int i = 0; i < j; i++){
                     points[i] = (1-t)*points[i] + t*points[i+1];
                 }
             }
             
             curvedPoints.Add(points[0]);
         }
         
         return(curvedPoints.ToArray());
     }
}
