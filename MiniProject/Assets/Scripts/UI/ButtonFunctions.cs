using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFunc
{
	public static void RestartGame(PointerEventData data)
	{
		Manager.Instance.SceneM.LoadScene(SceneType.MainScene);
	}
	public static void GoStageSelectScene(PointerEventData data)
	{
		Manager.Instance.SceneM.LoadScene(SceneType.StageScene);
	}
}
