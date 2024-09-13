using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_StageSelect : UI_Base
{
	public int Stage { get; set; } = 0;
	enum Texts
	{
		StageLabel,
		StageText
	}
	enum Buttons
	{
		StageSelectButton
	}

	public override void Init()
	{
		Bind<TextMeshProUGUI>(typeof(Texts));
		Bind<Button>(typeof(Buttons));
		Button button = GetButton((int)Buttons.StageSelectButton);
		BindEvent(button.gameObject, LoadStage, UIEveneType.Click);
		GetText((int)Texts.StageText).text = Stage.ToString();
		if (!Manager.Instance.StageM.IsOpenStage(Stage))
		{
			button.GetComponent<UI_EventHandler>().enabled = false;
			button.gameObject.GetComponent<Image>().color = Color.gray;
		}
	}
	public void LoadStage(PointerEventData data)
	{
		Manager.Instance.StageM.LoadStage(Stage);
	}

}
