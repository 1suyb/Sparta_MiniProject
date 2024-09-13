using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageList : MonoBehaviour
{
	[SerializeField] private GameObject stageButton;

	private void Start()
	{
		Init();
	}
	public void Init()
	{
/*		for(int i = 0; i < StageManager.Instance.StageCount; i++) {
			GameObject go = Instantiate(stageButton,this.transform);
			go.GetComponent<StageLoader>().Init(i);
		}
		if (PlayerPrefs.HasKey("hidden")){
			GameObject go = Instantiate(stageButton,this.transform);
			go.GetComponent<StageLoader>().HiddenInit();
		}*/
	}
}
