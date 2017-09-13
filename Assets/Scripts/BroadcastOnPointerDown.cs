using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BroadcastOnPointerDown : MonoBehaviour, IPointerDownHandler
{	
	public string message;

	public SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver;

	public void OnPointerDown(PointerEventData eventData)
    {
		Debug.Log("ButtonDown Sent");
		SendMessageUpwards(message, sendMessageOptions);
	}
}
