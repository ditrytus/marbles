using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Curve : MonoBehaviour {

	public Transform[] points;

	public LineRenderer lineRenderer;

	private Vector3[] oldPointsPositions;

    public Vector3[] positions;

    public float length;

	public float smoothness = 3.0f;

    private Vector3[] tempPositions;

	// Use this for initialization
	void Start ()
    {
        oldPointsPositions = points.Select(p => p.position).ToArray();
        tempPositions = new Vector3[points.Length];
        positions = new Vector3[(points.Length * Mathf.RoundToInt(smoothness))];

        SetPoints();
    }

    private void SetPoints()
    {
        for (int i=0; i<points.Length; i++)
        {
            oldPointsPositions[i] = points[i].position;
        }

        MakeSmoothCurve();
        SetLength();
        RenderCurve();
    }

    private void SetLength()
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

    private void RenderCurve()
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
		bool changed = true;
		if (points.Length == oldPointsPositions.Length)
		{
			changed = false;
			for(int i=0; i<points.Length; i++)
			{
				if (points[i].position != oldPointsPositions[i])
				{
					changed = true;
				}
			}
		}
		if (changed)
		{
			SetPoints();
		}
	}

	public void MakeSmoothCurve()
	{    
         float t = 0.0f;

         for(int pointInTimeOnCurve = 0; pointInTimeOnCurve < positions.Length; pointInTimeOnCurve++)
         {
             t = Mathf.InverseLerp(0, positions.Length-1, pointInTimeOnCurve);
             
             for (int i = 0; i<points.Length; i++)
             {
                tempPositions[i] = points[i].position;
             }
             
             for(int j = points.Length-1; j > 0; j--)
             {
                 for (int i = 0; i < j; i++)
                 {
                     tempPositions[i] = (1 - t) * tempPositions[i] + t * tempPositions[i + 1];
                 }
             }
             
             positions[pointInTimeOnCurve] = tempPositions[0];
         }
     }
}
