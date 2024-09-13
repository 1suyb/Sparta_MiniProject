using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class StageManager
{
	public int NowStage { get; private set; }
	public List<Sprite> Sprites { get; private set; } = new List<Sprite>();
	public int CardCount { get { return Sprites.Count * 2; }}

	public int MaxStage { get; private set; }
	public int MaxHiddenStage { get; private set; }


	public void Init()
	{
		GameInfo info = Resources.Load<GameInfo>($"Data/GameInfo");
		MaxStage = info.StageCount;
		MaxHiddenStage = info.HiddenCount;
	}

	public bool IsOpenStage(int stage)
	{
		int[] clearRecord = PlayerData.ClearRecord;
		if(stage == 0)
			return true;
		if (clearRecord[stage] > 0)
		{
			return true;
		}
		else
		{
			if (clearRecord[stage-1] > 0)
				return true;
			else
				return false;
		}
	}

	public void LoadStage(int stage)
	{
		NowStage = stage;
		Sprites = Resources.Load<StageData>($"Data/Stage{stage}").sprites;
		Manager.Instance.SceneM.LoadScene(SceneType.MainScene);
	}
	public void StageClear()
	{
		PlayerData.SaveClearRecord(NowStage);
	}

}
