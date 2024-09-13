using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "ScriptableObjects/GameInfo", order = 1)]
public class GameInfo : ScriptableObject
{
	public int StageCount = 4;
	public int HiddenCount = 1;
}
