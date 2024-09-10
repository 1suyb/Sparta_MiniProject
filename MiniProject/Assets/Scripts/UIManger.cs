using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
	public static UIManger Instance;

	[SerializeField] private GameObject clearPanel;
	[SerializeField] private GameObject failPanel;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		else
			Destroy(this.gameObject);
	}

	public void Clear()
	{
		clearPanel.SetActive(true);
	}
	public void Fail()
	{
		failPanel.SetActive(true);
	}
}
