using UnityEngine;
using UniRx;
using System;

public class PanOnTouch : MonoBehaviour {

	const int TouchIndex = 0;

	private Camera cam;

	private IDisposable touch;

	public bool constraintX;

	public bool constraintY;

	public bool constraintZ;

	public Vector3 originalPosition;

	void Start () {
		cam = GetComponent<Camera>();

		originalPosition = transform.position;
		
		var oneTouch = Observable.EveryUpdate()
			.Where(_ => Input.touchCount > TouchIndex)
			.Select(_ => Input.GetTouch(TouchIndex));

		oneTouch
			.Where(t => t.phase == TouchPhase.Began)
			.Subscribe(__ => {
				touch = Observable.EveryUpdate()
					.Where(_ => Input.touchCount > TouchIndex)
					.Select(_ => Input.GetTouch(TouchIndex))
					.Pairwise()
					.Select(t => (Vector3)(t.Previous.position - t.Current.position) * cam.orthographicSize / cam.pixelHeight * 2f)
					.Subscribe(p => {
						var newPosition = transform.position + transform.TransformDirection(p);
						transform.position = new Vector3(
							constraintX ? originalPosition.x : newPosition.x,
							constraintY ? originalPosition.y : newPosition.y,
							constraintZ ? originalPosition.z : newPosition.z
						);
						
					});
			});

		oneTouch
			.Where(t => t.phase == TouchPhase.Ended | t.phase == TouchPhase.Canceled)
			.Subscribe(_ => touch.Dispose());
	}
}
