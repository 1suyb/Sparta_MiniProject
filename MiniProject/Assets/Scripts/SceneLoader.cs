using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] protected List<string> _scenes = new List<string> { "StartScene","StageScene","MainScene"};

	public void SceneLoad(int sceneNumber)
	{
		if (sceneNumber == 1) { SoundManager.instance.GameStart(); }
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(_scenes[sceneNumber]);
	}

}
