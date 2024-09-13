using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public enum State
{
	Wait,
	OnGoing,
	Warning,
	End,
}
public class CardGameLogic : MonoBehaviour
{
	private State _gameState;
	public bool isClear = false;

	private Card firstCard = null;
	private Card secondCard = null;

	private float _waitTime = 0.5f;
	private float _totalTime = 30.0f;
	private TextMeshProUGUI _timerText;
	public Action TimeOver = null;
	public Action TimeWarning = null;
	public Action Clear = null;

	public int LeftCard { get; private set; }

	public void Init()
	{
		LeftCard = Manager.Instance.StageM.CardCount;
		_gameState = State.Wait;
		TimeOver -= GameOver;
		TimeOver += GameOver;

		UI_GameScene go = GameObject.Find("GameScene").GetComponent<UI_GameScene>();
		_timerText = go.TimerText;
		TimeWarning -= go.TimeWarningText;
		TimeWarning += go.TimeWarningText;

		Clear -= GameClear;
		Clear += GameClear;

	}

	public void MatchedCard(Card card)
	{
		if (firstCard == null)
			firstCard = card;
		else 
		{ 
			secondCard = card;
			if (firstCard.Name == secondCard.Name)
			{
				firstCard.RemoveCard();
				secondCard.RemoveCard();
				Manager.Instance.SoundM.Play(Sounds.E_Match);
				LeftCard -= 2;
				if (LeftCard == 0)
				{
					Clear.Invoke();
				}
			}
			else
			{
				firstCard.CardClose();
				secondCard.CardClose();
				Manager.Instance.SoundM.Play(Sounds.E_MissMatch);
			}
			firstCard = null;
			secondCard = null;
		}
	}

	private void Update()
	{
		switch (_gameState)
		{
			case State.Wait:
				_waitTime -= Time.deltaTime;
				if (_waitTime < 0)
					_gameState = State.OnGoing;
				break;
			case State.OnGoing:
				if (_totalTime < 10f)
				{
					_gameState = State.Warning;
					Manager.Instance.SoundM.Play(Sounds.B_WarningMusic);
					TimeWarning.Invoke();
					break;
				}
				goto case State.Warning;
			case State.Warning:
				if (_totalTime <= 0)
				{
					_gameState = State.End;
					TimeOver.Invoke();
					break ;
				}
				_totalTime -= Time.deltaTime;
				_timerText.text = _totalTime.ToString("N2");
				break;
		}
	}

	public void GameClear()
	{
		_gameState = State.End;
		Manager.Instance.UIM.ShowPopupUI("UI/Popup/ClearPopup");
		Manager.Instance.StageM.StageClear();
		Manager.Instance.SoundM.Stop();
		Manager.Instance.SoundM.Play(Sounds.E_Clear);
	}
	public void GameOver()
	{
		Manager.Instance.UIM.ShowPopupUI("UI/Popup/FailedPopup");
		Manager.Instance.SoundM.Stop();
		Manager.Instance.SoundM.Play(Sounds.E_Failed);
	}

}
