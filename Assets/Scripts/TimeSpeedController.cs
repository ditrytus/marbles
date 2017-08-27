using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeSpeedController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public FloatRange timeScaleRange = new FloatRange(){min=3, max=15};
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = timeScaleRange.max;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Time.timeScale = timeScaleRange.min;
    }
}
