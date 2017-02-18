using UnityEngine;
using UniRx;
using System;

public class PanOnTouch : MonoBehaviour {

	const int TouchIndex = 0;

	private Camera cam;

	private IDisposable touch;

	private Vector3 velocity;

	private IDisposable inertia;

	public bool constraintX;

	public bool constraintY;

	public bool constraintZ;

	public float glide;

	void Start () {
		cam = GetComponent<Camera>();

		var oneTouch = Observable.EveryUpdate()
			.Where(_ => Input.touchCount > TouchIndex)
			.Select(_ => Input.GetTouch(TouchIndex));

		oneTouch
			.Where(t => t.phase == TouchPhase.Began)
			.Subscribe(__ => {
				if (inertia != null)
				{
					inertia.Dispose();
				}

				touch = Observable.EveryUpdate()
					.Where(_ => Input.touchCount > TouchIndex)
					.Select(_ => Input.GetTouch(TouchIndex))
					.Pairwise()
					.Select(t => { 
						var d = (Vector3)(t.Previous.position - t.Current.position) * cam.orthographicSize / cam.pixelHeight * 2f;

						var c = d / Mathf.Sin(0.5f * Mathf.PI - Mathf.Deg2Rad * Vector3.Angle(transform.up, Vector3.up));

						return c;
					})
					.Select(d => new Vector3(
						constraintX ? 0.0f : d.x,
						constraintY ? 0.0f : d.y,
						constraintZ ? 0.0f : d.z))
					.Subscribe(v => {
						velocity = v;
						transform.position += v;
					});
			});

		oneTouch
			.Where(t => t.phase == TouchPhase.Ended | t.phase == TouchPhase.Canceled)
			.Subscribe(_ => {
				touch.Dispose();

				inertia = Observable.EveryUpdate()
					.Select(__ => Time.smoothDeltaTime)
					.Scan((t,d) => t + d)
					.Select(time => Vector3.Lerp(velocity, Vector3.zero, time / glide))
					.Subscribe(v => {
						transform.position += v;
					});
			});
	}
}
