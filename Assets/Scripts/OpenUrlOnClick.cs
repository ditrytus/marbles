using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenUrlOnClick : MonoBehaviour, IPointerClickHandler
{
	public string url;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }
}
