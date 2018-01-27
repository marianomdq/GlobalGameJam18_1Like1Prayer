using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public AudioClip MainMusicClip;
	public AudioClip MainMenuClip;

	public static AudioManager instance = null;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		sfxSource.clip = clip;

		//Play the clip.
		sfxSource.Play();
	}

	//RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
	public void RandomizeSfx(params AudioClip[] clips)
	{
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);
		
		//Set the clip to the clip at our randomly chosen index.
		sfxSource.clip = clips[randomIndex];

		//Play the clip.
		sfxSource.Play();
	}

	//Used to play single sound clips.
	public void PlayMusic(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		sfxSource.clip = clip;

		//Play the clip.
		sfxSource.Play();
	}

	public void FadeOutAndPlayMainMusic(float FadeTime)
	{
		StartCoroutine(FadeOutAndPlayMainMusicCoroutine(FadeTime));
	}

	private IEnumerator FadeOutAndPlayMainMusicCoroutine(float FadeTime)
	{
		float startVolume = musicSource.volume;

		while (musicSource.volume > 0)
		{
			musicSource.volume -= startVolume * Time.deltaTime / FadeTime;

			yield return null;
		}

		musicSource.Stop();
		musicSource.volume = startVolume;
		PlayMusic(MainMusicClip);
	}
}
