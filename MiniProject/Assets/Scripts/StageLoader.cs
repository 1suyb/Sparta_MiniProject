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
	[SerializeField] private Animator animator;
	private void Start()
	{
		
	}
	public void MoveStage()
	{
		animator.Play("Click");
		Invoke("move", 0.1f);
	}
	private void move()
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
			if (Stage == 0) { animator.Play("Open"); }
			else
			{
				if (StageManager.Instance.ClearRecords[Stage - 1] > 0)
				{
					animator.Play("Open");
				}
				else
				{
					animator.SetBool("Closed", true);
					this.gameObject.GetComponent<Button>().enabled = false;
				}
			}
		}
		else
		{
			animator.SetBool("Open", false);
			animator.SetBool("Closed", false);
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
		if (!animator.GetBool("Closed"))
		{
			Debug.Log("over");
			animator.SetBool("Hover", true);
		}
		
	}
	public void OnMouseExit()
	{
		if (!animator.GetBool("Closed"))
		{
			animator.SetBool("Hover", false);
		}
	}
}
