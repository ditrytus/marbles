using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Curver : MonoBehaviour {

	public Transform[] points;

	public LineRenderer lineRenderer;

	private Vector3[] oldPositions;

	public float smoothness = 3.0f;

	// Use this for initialization
	void Start ()
    {
        var positions = GetPositions();
        oldPositions = positions;

        RenderCurve(positions);
    }

    private Vector3[] GetPositions()
    {
        return points.Select(p => p.position).ToArray();
    }

    private void RenderCurve(Vector3[] positions)
    {
		positions = MakeSmoothCurve(positions, smoothness);

        lineRenderer.numPositions = positions.Length;
        for (int i = 0; i < positions.Length; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }
    }

    // Update is called once per frame
    void Update ()
	{
		var positions = GetPositions();
		bool changed = true;
		if (positions.Length == oldPositions.Length)
		{
			changed = false;
			for(int i=0; i<positions.Length; i++)
			{
				if (positions[i] != oldPositions[i])
				{
					changed = true;
				}
			}
		}
		if (changed)
		{
			oldPositions = positions;
			RenderCurve(positions);
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
         
         curvedLength = (pointsLength*Mathf.RoundToInt(smoothness))-1;
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
