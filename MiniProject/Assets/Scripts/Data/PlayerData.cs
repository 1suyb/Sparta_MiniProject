using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public static class PlayerData
{
	private static string[] _stageValeus = new string[] { "stage1", "stage2", "stage3", "stage4" };
	public static int[] ClearRecord { 
		get {
			int[] recoreds = new int[4];
			for(int i = 0; i <_stageValeus.Length;i++)
			{
				if (PlayerPrefs.HasKey(_stageValeus[i]))
					recoreds[i] = PlayerPrefs.GetInt(_stageValeus[i]);
			}
			return recoreds;
		} 
	}
	public static void SaveClearRecord(int stage)
	{
		if (PlayerPrefs.HasKey(_stageValeus[stage]))
			PlayerPrefs.SetInt(_stageValeus[stage], ClearRecord[stage]);
		else
			PlayerPrefs.SetInt(_stageValeus[stage], 1);

		PlayerPrefs.Save();
	}

}
