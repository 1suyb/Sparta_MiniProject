using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
 public struct SpriteList
{
	[SerializeField] public List<Sprite> list;
}
public class StageManager : MonoBehaviour
{
	public static StageManager Instance;

	[SerializeField] private List<SpriteList> stages = new List<SpriteList>();
	[SerializeField] private SpriteList hiddenstage = new SpriteList();

	private int nowStage = 0;
	private List<string> playerDataKeys = new List<string>();// { "stage0", "hidden" };
	public int NowStage {  get { return nowStage; } set { if (value < StageCount) nowStage = value; } }
	public SpriteList StageSprites { 
		get { 
			if (NowStage == -1)
			{
				return hiddenstage;
			}
			return stages[nowStage]; } }
	public int StageCount { get { return stages.Count; } }

	[SerializeField] private int[] clearRecords;
	public int[] ClearRecords { 
		get 
		{
			int[] result = new int[StageCount];
			for (int i = 0; i < stages.Count; i++)
			{
				if (PlayerPrefs.HasKey(playerDataKeys[i]))
				{
					result[i] = PlayerPrefs.GetInt(playerDataKeys[i]);
				}
			}
			return result;
		} 
	}
	public void SaveClearRecords(int stage)
	{
		if (PlayerPrefs.HasKey(playerDataKeys[stage]))
		{
			PlayerPrefs.SetInt(playerDataKeys[stage], ClearRecords[stage] + 1);
		}
		else
		{
			PlayerPrefs.SetInt(playerDataKeys[stage], 1);
		}
	}

	private void Awake()
	{

		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		else
			Destroy(this.gameObject);
		for (int i = 0;i<StageCount;i++)
		{
			playerDataKeys.Add($"stage{i}");
		}
	}
	
	private void Start()
	{
		clearRecords = ClearRecords;
	}
	public void ClearStage()
	{
		SaveClearRecords(nowStage);
	}
	public void OpenHiddenStage()
	{
		PlayerPrefs.SetInt("hidden", 1);
		PlayerPrefs.Save();
	}
}
