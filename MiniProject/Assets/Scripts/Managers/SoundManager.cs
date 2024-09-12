
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
	BGM,
	Effect,
	MaxCount,
}

public class SoundManager
{
	private readonly string _soundRoot = "@Sound";
	private AudioSource[] _audioSource = new AudioSource[(int)SoundType.MaxCount];
	private Dictionary<string, AudioClip> _audioCache = new Dictionary<string, AudioClip>();

	public void Init()
	{
		GameObject root = GameObject.Find(_soundRoot);
		if (root == null)
		{
			root = new GameObject() { name = _soundRoot };
			Object.DontDestroyOnLoad(root);
			string[] soundNames = System.Enum.GetNames(typeof(SoundType));
			for (int i = 0; i < (int)SoundType.MaxCount; i++)
			{
				GameObject go = new GameObject() { name = soundNames[i] };
				_audioSource[i] = go.GetorAddComponent<AudioSource>();
				go.transform.parent = root.transform;
			}
			_audioSource[(int)SoundType.BGM].loop = true;
		}
	}

	public void Play(string path, SoundType type = SoundType.Effect, float pitch = 1.0f)
	{
		AudioClip clip = TryGetClip(path, type);
		Play(clip,type,pitch);
	}
	public void Play(AudioClip audioClip, SoundType type = SoundType.Effect, float pitch = 1.0f)
	{

		if (type == SoundType.Effect)
		{

			AudioSource audioSource = _audioSource[(int)SoundType.Effect];
			audioSource.pitch = pitch;
			audioSource.PlayOneShot(audioClip);
		}
		else
		{
			AudioSource audioSource = _audioSource[(int)SoundType.BGM];
			audioSource.pitch = pitch;
			audioSource.clip = audioClip;
			audioSource.Play();
		}
	}

	public AudioClip TryGetClip(string path, SoundType type = SoundType.Effect)
	{
		if (!path.Contains("Sound/"))
			path = $"Sound/{path}";
		AudioClip audioClip = null;
		if (type == SoundType.Effect)
		{
			if (!_audioCache.TryGetValue(path, out audioClip))
				audioClip = Resources.Load<AudioClip>(path);
		}
		else
			audioClip = Resources.Load<AudioClip>(path);
		return audioClip;
	}
}
