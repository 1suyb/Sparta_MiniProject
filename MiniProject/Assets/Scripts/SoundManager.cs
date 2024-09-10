using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	[SerializeField] private AudioClip matched;
	[SerializeField] private AudioClip mismatched;

	[SerializeField] private AudioClip cardflip;

	[SerializeField] private AudioClip backgorund;
	[SerializeField] private AudioClip game;
	[SerializeField] private AudioClip noManyTime;
	[SerializeField] private AudioClip clear;
	[SerializeField] private AudioClip fail;
	[SerializeField] private AudioSource audiosource;

	public AudioClip Matched { get { return matched; } }
	public AudioClip Mismatched { get {  return mismatched; } }
	public AudioClip Cardflip { get {  return cardflip; } }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
		
	}

	private void Start()
	{
		audiosource = GetComponent<AudioSource>();
		GameStart();
	}
	public void MainStart()
	{
		audiosource.clip = game;
		audiosource.Play();
	}
	public void GameStart()
	{
		audiosource.clip = backgorund;
		audiosource.Play();
	}
	public void GameClear()
	{
		audiosource.PlayOneShot(clear);
	}
	public void GameFail()
	{
		audiosource.PlayOneShot(fail);
	}
	public void NoManyTime()
	{
		audiosource.clip = noManyTime;
		audiosource.Play();
	}
}
