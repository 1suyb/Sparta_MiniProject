using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private float totaltime = 30f;
	[SerializeField] private TextMeshProUGUI timeText;

	public float TotalTime {  get { return totaltime; } }
	private bool changeMusic = false;

	private void Update()
	{
		totaltime -= Time.deltaTime;
		timeText.text = totaltime.ToString("N2");
		if(totaltime < 10 && !changeMusic)
		{
			changeMusic = true;
			SoundManager.instance.NoManyTime();
			timeText.color = Color.red;
		}
		if (totaltime <= 0)
		{
			GameManager.Instance.GameOver();
		}
	}
}
