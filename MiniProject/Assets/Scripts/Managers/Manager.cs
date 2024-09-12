using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	private static string _managerObjectName = "@Manager";
	private static Manager _instance;

	private SceneManagerEX _sceneManager = new SceneManagerEX();

	public Manager Instance { get { Init(); return _instance; } }
	public SceneManagerEX SceneManager { get { return _sceneManager; } }

	public void Init()
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
		}
	}
}
