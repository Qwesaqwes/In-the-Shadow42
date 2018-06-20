using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
	public Music[] sounds;
	public static AudioManager instance;

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
		foreach(Music s in sounds)	
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	
	public void Play(string name)
	{
		Music s = Array.Find(sounds, Music => Music.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();
	}

	public void Stop(string name)
	{
		Music s = Array.Find(sounds, Music => Music.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop();
	}
}
