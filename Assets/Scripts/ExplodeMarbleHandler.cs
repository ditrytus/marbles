using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeMarbleHandler : MonoBehaviour
{
	public GameObject particlePrefab;

	public void ExplodeMarble ()
	{
		var explosion = Instantiate(particlePrefab, transform.position, transform.rotation);
		explosion.SendMessage(MarbleColorController.SetMarbleColorMessage, gameObject.GetComponent<MarbleColorController>().color);
		Destroy(gameObject);
	}
}
