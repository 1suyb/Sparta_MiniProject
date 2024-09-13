using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_FailedPopup : UI_Popup
{ 
	enum Texts
	{
		FailedLabel,
		RetryText,
		StageSelectText,
	}

	enum Buttons
	{
		Retry,
		StageSelect,
	}

	public void Start()
	{
		Init();
	}
	public override void Init()
	{
		base.Init();
		Bind<TextMeshProUGUI>(typeof(Texts));
		Bind<Button>(typeof(Buttons));

		BindEvent(GetButton((int)Buttons.Retry).gameObject, LoadSceneButton.RestartGame, UIEveneType.Click);
		BindEvent(GetButton((int)Buttons.StageSelect).gameObject, LoadSceneButton.GoStageSelectScene, UIEveneType.Click);
	}
}
