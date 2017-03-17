using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMarbleColorMaterialHandler : MonoBehaviour {

	public void SetMarbleColorMaterial(Material material)
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = material;
        }
    }
}
