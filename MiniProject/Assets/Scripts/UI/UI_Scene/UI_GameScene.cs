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

	public TextMeshProUGUI StageText { get; private set; }
	public TextMeshProUGUI TimerText { get; private set; }

	private void Start()
	{
		Init();
	}

	public override void Init()
	{
		base.Init();
		Bind<TextMeshProUGUI>(typeof(Texts));
		GetText((int)Texts.StageLabel).text = "Stage";
		StageText = GetText((int)Texts.StageText);
		GetText((int)Texts.TimerLabel).text = "남은시간";
		TimerText = GetText((int)Texts.TimerText);
	}
	public void TimeWarningText()
	{
		TimerText.color = Color.red;
	}
}
