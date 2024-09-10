using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageLoader : SceneLoader
{
	private int stage;
	private bool isActive;
	public int Stage { get { return stage; } set { if (value < StageManager.Instance.StageCount) { stage = value; } } }

	[SerializeField] private TextMeshProUGUI stageText;
	private Animator animator;
	private void Start()
	{
		
	}
	public void MoveStage()
	{
		StageManager.Instance.NowStage = Stage;
		SoundManager.instance.MainStart();
		SceneManager.LoadScene(_scenes[2]);
	}
	public void Init(int stage)
	{
		animator = GetComponent<Animator>();
		Stage = stage;
		stageText.text=Stage.ToString();

		if (StageManager.Instance.ClearRecords[Stage] == 0)
		{
			if (Stage == 0) { this.gameObject.GetComponent<Image>().color = Color.green; }
			else
			{
				if (StageManager.Instance.ClearRecords[Stage - 1] > 0)
				{
					this.gameObject.GetComponent<Image>().color = Color.green;
				}
				else
				{
					this.gameObject.GetComponent<Image>().color = Color.gray;
					this.gameObject.GetComponent<Button>().enabled = false;
				}
			}
		}
	}
	public void HiddenInit()
	{
		stage = -1;
		stageText.text=Stage.ToString();
		this.gameObject.GetComponent<Image>().color = Color.red;
	}
	public void OnMouseOver()
	{
		Debug.Log("over");
		animator.SetBool("Hover", true);
	}
	public void OnMouseExit()
	{
		animator.SetBool("Hover", false);
	}
}
