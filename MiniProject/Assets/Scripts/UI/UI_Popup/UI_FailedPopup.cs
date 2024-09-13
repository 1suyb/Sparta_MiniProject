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

	[SerializeField] AudioClip clip;

	public override void Init()
	{
		base.Init();
		Manager.Instance.SoundM.Play(clip);
		Bind<TextMeshProUGUI>(typeof(Texts));
		Bind<Button>(typeof(Buttons));

		BindEvent(GetButton((int)Buttons.Retry).gameObject, ButtonFunc.RestartGame, UIEveneType.Click);
		BindEvent(GetButton((int)Buttons.StageSelect).gameObject, ButtonFunc.GoStageSelectScene, UIEveneType.Click);
	}
}
