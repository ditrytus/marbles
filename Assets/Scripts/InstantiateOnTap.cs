using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InstantiateOnTap : RxBehaviour {

	public Camera tapCamera;
	
	public GameObject prefab;

	public LayerMask layer;

	void Start () {
		var sub1 = Observable.EveryUpdate()
			.SelectMany(_ => Input.touches)
			.Where(touch => touch.phase == TouchPhase.Began)
			.Subscribe(touch => {
				var ray = tapCamera.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, float.MaxValue, layer.value))
				{
					Instantiate(prefab, hit.point, Random.rotation);
				}
			});

		AddSubscriptions(sub1);
	}
}
