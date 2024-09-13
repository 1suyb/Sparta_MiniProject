using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObjects/SoundData", order = 2)]
public class SoundData : ScriptableObject
{
	public AudioClip B_BackGroundMusic;
	public AudioClip B_PlaygroundMusic;
	public AudioClip B_WarningMusic;

	public AudioClip E_CardFlip;
	public AudioClip E_Match;
	public AudioClip E_MissMatch;
	public AudioClip E_Clear;
	public AudioClip E_Failed;
}
