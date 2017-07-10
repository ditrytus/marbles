using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
	public Animator animator;

    public void Show()
    {
        animator.SetTrigger("Pause");
    }

    public void Hide()
    {
        animator.SetTrigger("Resume");
    }
}
