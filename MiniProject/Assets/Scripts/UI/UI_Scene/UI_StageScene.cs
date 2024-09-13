using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StageScene : UI_Scene
{
	enum Texts
	{
		StageLabel,
	}
	enum GameObjects
	{
		StageSelectPanel,
	}
	private void Start()
	{
		Init();
	}
	public override void Init()
	{
		Bind<TextMeshProUGUI>(typeof(Texts));
		Bind<GameObject>(typeof(GameObjects));
		GameObject stageSelectPanel = GetGameObject((int)GameObjects.StageSelectPanel);
		GameObject stageSelectorOri = Resources.Load<GameObject>("UI/SubItem/StageSelector");
		GameObject stageSelector = null;
		for (int i = 0; i < Manager.Instance.StageM.MaxStage; i++)
		{
			stageSelector = GameObject.Instantiate(stageSelectorOri, stageSelectPanel.transform);
			UI_StageSelect selector = stageSelector.GetorAddComponent<UI_StageSelect>();
			selector.Stage = i;
			selector.Init();
		}

	}
}
