using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMarbleParticleColor : MonoBehaviour {

	public void SetMarbleColorColor(Color color)
    {
        var particleSystem = GetComponent<ParticleSystem>();
        var main = particleSystem.main;
		main.startColor = color;
    }
}
