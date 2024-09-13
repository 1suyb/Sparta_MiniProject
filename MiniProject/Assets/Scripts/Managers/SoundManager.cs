
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
	BGM,
	Effect,
	MaxCount,
}

public enum Sounds
{
	B_BackGroundMusic,
	B_PlaygroundMusic,
	B_WarningMusic,
	E_CardFlip,
	E_Match,
	E_MissMatch,
	E_Clear,
	E_Failed,
}

public class SoundManager
{
	private readonly string _soundRoot = "@Sound";
	private AudioSource[] _audioSource = new AudioSource[(int)SoundType.MaxCount];
	private Dictionary<string, AudioClip> _audioCache = new Dictionary<string, AudioClip>();
	public SoundData SoundData { get; private set; }

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
			SoundData = Resources.Load<SoundData>("Data/SoundData");
		}
	}

	public void Play(Sounds sound)
	{
		switch (sound)
		{
			case Sounds.B_BackGroundMusic:
				Play(SoundData.B_BackGroundMusic, SoundType.BGM);
				break;
			case Sounds.B_PlaygroundMusic:
				Play(SoundData.B_PlaygroundMusic, SoundType.BGM);
				break;
			case Sounds.B_WarningMusic:
				Play(SoundData.B_WarningMusic, SoundType.BGM);
				break;
			case Sounds.E_CardFlip:
				Play(SoundData.E_CardFlip);
				break;
			case Sounds.E_Match:
				Play(SoundData.E_Match);
				break;
			case Sounds.E_MissMatch:
				Play(SoundData.E_MissMatch);
				break;
			case Sounds.E_Clear:
				Play(SoundData.E_Clear);
				break;
			case Sounds.E_Failed:
				Play(SoundData.E_Clear);
				break;
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

	public void Stop()
	{
		_audioSource[(int)SoundType.BGM].Stop();
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
