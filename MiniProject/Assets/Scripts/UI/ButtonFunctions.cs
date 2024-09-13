using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadSceneButton
{
	public static void RestartGame(PointerEventData data)
	{
		Debug.Log("ธิศ๗ฑไวิ");
		Manager.Instance.UIM.ClosePopupUI();
		Manager.Instance.SceneM.LoadScene(SceneType.MainScene);
	}
	public static void GoStageSelectScene(PointerEventData data)
	{
		Manager.Instance.UIM.ClosePopupUI();
		Manager.Instance.SceneM.LoadScene(SceneType.StageScene);
	}
}
