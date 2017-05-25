using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class BoundingBox : MonoBehaviour {

    public Bounds totalBounds = new Bounds();

    void Start()
	{
		var renderer = GetComponent<Renderer>();
        if(renderer!=null)
		{
			totalBounds = renderer.bounds;
		}
   
        AddChildrenToBounds(transform);
    }
   
     
   
    void AddChildrenToBounds(Transform child) {
   
        foreach (Transform grandChild in child)
		{
			var renderer = grandChild.GetComponent<Renderer>();
            if (renderer != null)
			{
				try
				{
					totalBounds.Encapsulate(renderer.bounds.min);
					totalBounds.Encapsulate(renderer.bounds.max);
				}
				catch { }
            }
   
            AddChildrenToBounds(grandChild);
        }
   
    }

    void OnDrawGizmosSelected()
	{
        Vector3 center = totalBounds.center;
        Vector3 size = totalBounds.size;
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube( center, size );
    }
}
