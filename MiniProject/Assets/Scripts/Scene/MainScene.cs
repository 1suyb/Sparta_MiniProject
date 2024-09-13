using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
	private readonly string _logicObjName = "@Logic";

	public void Start()
	{
		Init();
	}

	public override void Init()
	{
		base.Init();
		GameObject go = GameObject.Find( _logicObjName );
		if ( go == null)
		{
			go = new GameObject() { name = _logicObjName };
		}
		CardGameLogic logic = go.GetorAddComponent<CardGameLogic>();
		logic.Init();
		Manager.Instance.SoundM.Play(Sounds.B_PlaygroundMusic);
		GameObject boardObj = GameObject.Instantiate(Resources.Load<GameObject>("Board"));
		Board board = boardObj.GetComponent<Board>();
		board.SetBoard();
	}
}
