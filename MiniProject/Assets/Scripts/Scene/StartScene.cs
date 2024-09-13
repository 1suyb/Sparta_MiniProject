using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
	public void Start()
	{
		Init();
	}
	public override void Init()
	{
		Manager.Instance.SoundM.Play(Sounds.B_BackGroundMusic);
		PlayerPrefs.DeleteAll();
	}
}
