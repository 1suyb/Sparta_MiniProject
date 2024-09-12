using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
	StartScene,
	StageScene,
	MainScene,
}

public class SceneManagerEX
{
	public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

	public void LoadScene(SceneType sceneType)
	{
		SceneManager.LoadScene(Enum.GetName(typeof(SceneType), sceneType) );
	}

	public void Clear()
	{

	}
}
