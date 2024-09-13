using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GameScene : UI_Scene
{
	enum Texts
	{
		StageLabel,
		StageText,
		TimerLabel,
		TimerText,
	}

	private TextMeshProUGUI _stageText;
	private TextMeshProUGUI _timerText;

	private void Start()
	{
		Init();
	}

	public override void Init()
	{
		base.Init();
		Bind<TextMeshProUGUI>(typeof(Texts));
		GetText((int)Texts.StageLabel).text = "Stage";
		_stageText = GetText((int)Texts.StageText);
		GetText((int)Texts.TimerLabel).text = "남은시간";
		_timerText = GetText((int)Texts.TimerText);
	}
}
