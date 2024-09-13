using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartScene : UI_Scene
{
	enum Texts
	{
		ProjectNameLabel,
		StartButtonName
	}
	enum Buttons
	{
		StartButton
	}
	public void Start()
	{
		Init();
	}
	public override void Init()
	{
		Bind<TextMeshProUGUI>(typeof(Texts));
		Bind<Button>(typeof(Buttons));

		BindEvent(Get<Button>((int)Buttons.StartButton).gameObject,LoadSceneButton.GoStageSelectScene,UIEveneType.Click);
	}
}
