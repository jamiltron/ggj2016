using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip gameBkgMusic;

	/*public AudioClip welpNotificationSfx;
	public AudioClip newCustomerArrivalSfx;
	public AudioClip buttonClickSfx;*/
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
		sfxSource.clip = buttonUISfx;
		sfxSource.Play ();
	}

	public void PlaySoundEffect(AudioClip clip)
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
