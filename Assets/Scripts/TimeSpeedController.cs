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

    public float audioSourcesLoadDelay = 5.0f;

    void Start()
    {
        this.SetDefaultToName(ref rootWithAudio, defaultRootName);
        StartCoroutine(LoadAudioSources());
    }

    public IEnumerator LoadAudioSources()
    {
        yield return new WaitForSecondsRealtime(audioSourcesLoadDelay);
        audioSourcesWithPitch = rootWithAudio
            .GetComponentsInChildren<AudioSource>()
            .ToDictionary(a => a, a => a.pitch);
        yield break;
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
        foreach (var audioWithPitch in audioSourcesWithPitch)
        {
            if (audioWithPitch.Key != null)
            {
                audioWithPitch.Key.pitch = audioWithPitch.Value * pitchFactor;
            }
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
