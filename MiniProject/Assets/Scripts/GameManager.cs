using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private void Awake()
	{
		
		if (Instance == null)
		{
			Instance = this;
			PlayerPrefs.DeleteAll();
			DontDestroyOnLoad(this.gameObject);
		}
			
		else
			Destroy(this.gameObject);

		isClear = false;
	}

	public bool isClear = false;

	[HideInInspector] public Card firstCard = null;
	[HideInInspector] public Card secondCard = null;
	[HideInInspector] public int cardCount;

	private AudioSource audiosource;

	private void Start()
	{
		audiosource = GetComponent<AudioSource>();
	}


	public void MatchedCard()
	{
		if (firstCard != null && secondCard != null)
		{
			if (firstCard.Name == secondCard.Name)
			{
				firstCard.RemoveCard();
				secondCard.RemoveCard();
				audiosource.PlayOneShot(SoundManager.instance.Matched);
				cardCount -= 2;
				if (cardCount == 0)
				{
					isClear = true;
					Invoke("GameOver", 0.6f);
				}
			}
			else
			{
				firstCard.CardClose();
				secondCard.CardClose();
				audiosource.PlayOneShot(SoundManager.instance.Mismatched);
			}
		}
		firstCard = null;
		secondCard = null;
	}
	public void GameOver()
	{
		Time.timeScale = 0.0f;
		if (isClear)
		{
			SoundManager.instance.GameClear();
			UIManger.Instance.Clear();
			StageManager.Instance.ClearStage();
			if (StageManager.Instance.NowStage == 0)
			{
				GameObject go = GameObject.Find("Timer");
				if (go.GetComponent<Timer>().TotalTime >= 22.0f)
				{
					StageManager.Instance.OpenHiddenStage();
				}
			}
		}
		else
		{
			SoundManager.instance.GameFail();
			UIManger.Instance.Fail();
		}
	}
	
	public void GameStart()
	{
		SoundManager.instance.MainStart();
		isClear = false;
	}
}
