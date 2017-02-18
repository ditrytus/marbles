using UnityEngine;
using UniRx;
using System;

public class PanOnTouch : MonoBehaviour {

	public int touchIndex;

	public Vector2? prevTouchPosition;

	private Camera cam;

	private IDisposable touch;

	void Start () {
		cam = GetComponent<Camera>();
		
		var oneTouch = Observable.EveryUpdate()
			.Where(_ => Input.touchCount == 1)
			.Select(_ => Input.GetTouch(0));

		oneTouch
			.Where(t => t.phase == TouchPhase.Began)
			.Subscribe(__ => {
				touch = Observable.EveryUpdate()
					.Where(_ => Input.touchCount == 1)
					.Select(_ => Input.GetTouch(0))
					.Pairwise()
					.Select(t => (Vector3)(t.Previous.position - t.Current.position) * cam.orthographicSize / cam.pixelHeight * 2f)
					.Subscribe(p => {
						transform.position += transform.TransformDirection(p);
					});
			});

		oneTouch
			.Where(t => t.phase == TouchPhase.Ended | t.phase == TouchPhase.Canceled)
			.Subscribe(_ => touch.Dispose());
	}
}
