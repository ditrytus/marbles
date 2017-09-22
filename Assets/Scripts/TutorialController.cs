using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
	public Animator animator;

	public GameObject funnel;
	private TutorialDraggedTrigger draggedTrigger;

	public GameObject cameraSystem;
	private TutorialPannedTrigger pannedTrigger;


	void Awake()
	{
		this.SetDefaultFromThis(ref animator);
		
		draggedTrigger = funnel.AddComponent<TutorialDraggedTrigger>();
		draggedTrigger.tutorialController = this;
	}

	public void Dragged()
	{
		animator.SetTrigger("Dragged");
		draggedTrigger.enabled = false;
		pannedTrigger = cameraSystem.AddComponent<TutorialPannedTrigger>();
		pannedTrigger.tutorialController = this;
	}

	public void Panned()
	{
		animator.SetTrigger("Panned");
		pannedTrigger.enabled = false;
	}
}
