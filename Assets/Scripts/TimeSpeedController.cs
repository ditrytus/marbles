using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class TimeSpeedController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public FloatRange timeScaleRange = new FloatRange(){min=3, max=15};

    public GameObject rootWithAudio;

    public string defaultRootName;

    public float pitchFactor = 2.3f;

    private Dictionary<AudioSource, float> audioSourcesWithPitch;

    private bool isPressed = false;

    void Start()
    {
        this.SetDefaultToName(ref rootWithAudio, defaultRootName); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPressed)
        {
            return;
        }
        isPressed = true;
        Time.timeScale = timeScaleRange.max;
        IncreaseSoundPitch();
    }

    private void IncreaseSoundPitch()
    {
        audioSourcesWithPitch = rootWithAudio
            .GetComponentsInChildren<AudioSource>()
            .ToDictionary(a => a, a => a.pitch);       
        foreach (var audioWithPitch in audioSourcesWithPitch)
        {
            Debug.Log(string.Format("Pitch from: {0} to: {1}", audioWithPitch.Key.pitch, audioWithPitch.Value * pitchFactor));
            audioWithPitch.Key.pitch = audioWithPitch.Value * pitchFactor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isPressed)
        {
            return;
        }
        isPressed = false;
        Time.timeScale = timeScaleRange.min;
        RestoreOriginalSoundPitch();
    }

    private void RestoreOriginalSoundPitch()
    {
        foreach (var audioWithPitch in audioSourcesWithPitch)
        {
            if (audioWithPitch.Key != null)
            {
                audioWithPitch.Key.pitch = audioWithPitch.Value;
            }
        }
    }
}
