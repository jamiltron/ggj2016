using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip gameBkgMusic;
	public AudioClip welpNotificationSfx;
	public AudioClip newCustomerArrivalSfx;

	public AudioClip buttonUISfx;

	public AudioSource sfxSource;              
	public AudioSource bkgmusicSource;
	public static SoundManager instance = null;   

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public void PlayButtonClickSfx()
	{
		PlaySoundEffect(buttonUISfx);
	}

	public void PlayWelpNotification()
	{
		PlaySoundEffect (welpNotificationSfx);
	}

	public void PlayNewCustomerArrival()
	{
		PlaySoundEffect (newCustomerArrivalSfx);
	}

	void PlaySoundEffect(AudioClip clip)
	{
		sfxSource.clip = clip;
		sfxSource.Play ();
	}

	public void PlayGameBkgMusic()
	{
		bkgmusicSource.clip = gameBkgMusic;
		bkgmusicSource.Play ();
	}
}
