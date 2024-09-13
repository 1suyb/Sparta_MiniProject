using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	private static string _managerObjectName = "@Manager";
	private static Manager _instance;

	private SceneManagerEX _sceneManager = new SceneManagerEX();
	private UIManager _uiManager = new UIManager();
	private SoundManager _soundManager = new SoundManager();
	private StageManager _stageManager = new StageManager();

	public static Manager Instance { get { Init(); return _instance; } }
	public SceneManagerEX SceneM { get { return _sceneManager; } }
	public UIManager UIM { get { return _uiManager; } }
	public SoundManager SoundM { get { return _soundManager;} }
	public StageManager StageM { get { return _stageManager;} }

	public static void Init()
	{
		if (_instance == null)
		{
			GameObject go = GameObject.Find(_managerObjectName);
			if (go == null)
			{
				go = new GameObject() { name = _managerObjectName };
				go.AddComponent<Manager>();
			}
			_instance = go.GetComponent<Manager>();
			DontDestroyOnLoad(go);
			_instance.StageM.Init();
			_instance.SoundM.Init();
		}
	}
}
