using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsController : MonoBehaviour {

	private Settings settings;

	public Toggle soundToggle;
	public string defaultSoundToggleName;

	public Toggle musicToggle;
	public string defaultMusicToggleName;

	public AudioSource musicSource;

	private bool musicWasPlayed = false;

	void Awake ()
	{
		settings = new Settings();
		
		this.SetDefaultFromThis(ref musicSource);

		this.SetDefaultFromName(ref soundToggle, defaultSoundToggleName);
		this.SetDefaultFromName(ref musicToggle, defaultMusicToggleName);
		
		soundToggle.onValueChanged.AddListener(SoundValueChanged);
		musicToggle.onValueChanged.AddListener(MusicValueChanged);
		
	}

	void Start()
    {
		if (settings.MusicEnabled)
        {
            StartMusic();
        }

        ApplySoundSetting();

        musicToggle.isOn = settings.MusicEnabled;
        soundToggle.isOn = settings.SoundEnabled;
    }

    private void StartMusic()
    {
        musicSource.Play();
        musicWasPlayed = true;
    }

    private void ApplySoundSetting()
    {
        AudioListener.volume = settings.SoundEnabled ? 1.0f : 0.0f;
    }

    public void SoundValueChanged(bool soundEnabled)
	{
		settings.SoundEnabled = soundEnabled;
		musicToggle.interactable = soundEnabled;
		musicToggle.isOn = soundEnabled;
        ApplySoundSetting();
	}

	public void MusicValueChanged(bool musicEnabled)
	{
		settings.MusicEnabled = musicEnabled;
		if (musicEnabled)
		{
			if (musicWasPlayed)
			{
				musicSource.UnPause();
			}
			else
			{
            	StartMusic();
			}
		}
		else
		{
			musicSource.Pause();
		}
	}
}
