using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniRx;

public class InstantiateOnTap : RxBehaviour {

	public Camera camera;
	
	public GameObject prefab;

	public LayerMask layer;

	void Start () {
		var sub1 = Observable.EveryUpdate()
			.Where(_ => Input.touchCount > 0)
			.Subscribe(_ => {
				foreach(var touch in Input.touches)
				{
					if (touch.phase == TouchPhase.Began)
					{
						var ray = camera.ScreenPointToRay(touch.position);
						RaycastHit hit;
						if (Physics.Raycast(ray, out hit, float.MaxValue, layer.value))
						{
							Debug.Log(hit.collider.gameObject.name + " hit!");
							Instantiate(prefab, hit.point, Random.rotation);
						}
					}
				}
			});

		AddSubscriptions(sub1);
	}
}
